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
                // TODO: Authorization - Anfragen annehmen

                var userRepo = new UserRepository(EnvironmentVariable.GetValueOrDefault("ConnectionStringImageDB",
                    "host=localhost;database=spartakiade;password=sportfrei;username=spartakiade"));

                // TODO: Rückgabe 

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
