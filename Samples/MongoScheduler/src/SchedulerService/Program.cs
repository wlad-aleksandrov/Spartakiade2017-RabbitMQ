using System;
using EasyNetQ;
using EasyNetQ.Scheduling;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.SchedulerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                var messageRepository = new MessageRepository("mongodb://localhost");
                myBus = RabbitHutch.CreateBus("host=localhost");


                myBus.Subscribe<Announcement>("MongoScheduler", msg =>
                {
                    System.Console.WriteLine(msg);
                });

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }
            Console.ReadLine();
        }
    }
}
