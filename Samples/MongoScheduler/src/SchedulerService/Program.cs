using System;
using System.Threading.Tasks;
using EasyNetQ;
using FP.Spartakiade2017.MsRmq.MongoScheduler.MongoScheduler;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.SchedulerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            Scheduler scheduler = null;
            IDisposable subAnnouncement = null;
            IDisposable subCancelation = null;
            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost");
                var messageRepository = new MessageRepository("mongodb://localhost");

                // Anbindung an RabbitMQ
                // alte Nachrichten wieder einplanen
                
                
                Console.WriteLine("Scheduler is started");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                subCancelation?.Dispose();
                subAnnouncement?.Dispose();
                scheduler?.Dispose();
                myBus?.Dispose();
                
            }
            Console.ReadLine();
        }

     
    }
}
