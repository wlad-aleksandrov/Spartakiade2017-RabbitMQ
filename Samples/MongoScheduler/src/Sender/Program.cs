using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Scheduling;
using FP.Spartakiade2017.MsRmq.MongoScheduler.Contracts;
using FP.Spartakiade2017.MsRmq.MongoScheduler.MongoScheduler;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.Sender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                var messageRepository = new MessageRepository("mongodb://localhost");
                var mongoScheduler = new MongoScheduler.MongoScheduler(messageRepository);
                myBus = RabbitHutch.CreateBus("host=localhost", register => register.Register<IScheduler>(provider => mongoScheduler));
                mongoScheduler.AnnounceAction = id => myBus.PublishAsync(new Announcement {Id = id});

                StartSubscription(myBus);
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

        private static void StartSubscription(IBus myBus)
        {
            myBus.Subscribe<FutureMessage>("MyFutureMessageSubscription", msg => Console.WriteLine($"{DateTime.Now:T}: {msg.Content} (schedule at {msg.Timestamp:T})"));

        }

        private static void ScheduleMessage(IBus myBus)
        {
            string content = string.Empty;
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
