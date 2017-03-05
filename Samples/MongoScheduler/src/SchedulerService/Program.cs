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
                scheduler = new Scheduler(myBus, messageRepository);
                Reschedule(messageRepository, scheduler);
                subAnnouncement = myBus.SubscribeAsync<Announcement>("AnnouncementService", a => ExcuteAnnouncement(a, messageRepository, scheduler));
                subCancelation = myBus.SubscribeAsync<Cancelation>("CancelationService", c => ExecuteCancelation(c, messageRepository, scheduler));
                scheduler.Run();
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

        private static void Reschedule(MessageRepository messageRepository, Scheduler scheduler)
        {
            foreach (var msg in messageRepository.GetActiveMessages())
            {
                scheduler.AddJob(msg.Id.ToString(), msg.CancellationKey, msg.ExecuteTimestampUtc);
            }
        }

        private static Task ExecuteCancelation(Cancelation cancelation, MessageRepository messageRepository, Scheduler scheduler)
        {
            scheduler.CancelJob(cancelation.CancellationKey);
            return messageRepository.CancelMessage(cancelation.CancellationKey);
        }

        private static async Task ExcuteAnnouncement(Announcement announcement, MessageRepository messageRepository, Scheduler scheduler)
        {
            var messageId = await messageRepository.SaveFutureMessage(announcement.Message, announcement.CreateTimestampUtc,
                announcement.ExecuteTimestampUtc, announcement.Topic, announcement.CancellationKey);

            scheduler.AddJob(messageId, announcement.CancellationKey, announcement.ExecuteTimestampUtc);
        }
    }
}
