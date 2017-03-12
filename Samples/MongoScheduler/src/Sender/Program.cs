using System;
using EasyNetQ;
using EasyNetQ.Scheduling;
using FP.Spartakiade2017.MsRmq.MongoScheduler.Contracts;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.Sender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost",
                   register => register.Register<IScheduler, MongoScheduler.MongoScheduler>());

                ScheduleMessage(myBus);
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

        private static void ScheduleMessage(IBus myBus)
        {
            string content;
            do
            {
                Console.WriteLine("Enter the content or nothing to leave");
                content = Console.ReadLine();

                if (!string.IsNullOrEmpty(content))
                {
                    Console.WriteLine("Enter the delay in seconds");
                    var delayInSeconds = Convert.ToInt32(Console.ReadLine());

                    myBus.FuturePublish(TimeSpan.FromSeconds(delayInSeconds), new FutureMessage { Content = content });

                }
                System.Threading.Thread.Sleep(1000);
            } while (!string.IsNullOrEmpty(content));

        }
    }
}
