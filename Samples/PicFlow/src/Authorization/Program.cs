using System;
using System.Threading;
using EasyNetQ;
using FP.Spartakiade2017.PicFlow.Contracts;
using FP.Spartakiade2017.PicFlow.Contracts.Messages;

namespace FP.Spartakiade2017.PicFlow.Authorization
{
    public class Program
    {
        public static void Main(string[] args)
        {

            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus(EnvironmentVariable.GetValueOrDefault("ConnectionStringRabbitMQ","host=localhost"));
                var userRepo = new UserRepository(EnvironmentVariable.GetValueOrDefault("ConnectionStringImageDB",
                    "host=localhost;database=spartakiade;password=sportfrei;username=spartakiade"));
                myBus.SubscribeAsync<AuthenticationRequest>("Auth", async request =>
                {
                    var response = new AuthenticationResponse
                    {
                        Id = request.Id,
                    };

                    var userInfo = await userRepo.CheckUser(request.UserName, request.PasswordHash);
                    if (userInfo.IsValid)
                    {
                        response.UserId = userInfo.Id;
                        response.User = userInfo.User;
                        response.IsValid = true;
                    }

                    await myBus.PublishAsync(response);
                });

                Console.WriteLine("Authorization gestartet...");
                while (Console.ReadLine() != "quit") { Thread.Sleep(int.MaxValue); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Authorization - Verbindung ist fehlgeschlagen");
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }

            Console.WriteLine("Authorization beendet...");
        }

      
    }
}
