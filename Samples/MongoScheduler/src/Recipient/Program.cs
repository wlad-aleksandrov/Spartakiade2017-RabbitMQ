using System;
using EasyNetQ;
using FP.Spartakiade2017.MsRmq.MongoScheduler.Contracts;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.Recipient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost");
                myBus.Subscribe<FutureMessage>("FutureMessageSub", msg =>
                Console.WriteLine($"{DateTime.Now:T}: {msg.Content} (schedule at {msg.Timestamp:T})"));
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
