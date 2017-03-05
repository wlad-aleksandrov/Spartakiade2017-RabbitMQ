using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Scheduling;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.MongoScheduler
{
    public class MongoScheduler : IScheduler
    {
        private readonly IBus _bus;

        public MongoScheduler(IBus bus)
        {
            _bus = bus;
        }

        public Task FuturePublishAsync<T>(DateTime futurePublishDate, T message, string cancellationKey = null) where T : class
        {
            return FuturePublishAsync(futurePublishDate, message, string.Empty, cancellationKey);
        }

        public Task FuturePublishAsync<T>(DateTime futurePublishDate, T message, string topic, string cancellationKey = null) where T : class
        {
            var announcement = new Announcement
            {
                CancellationKey = cancellationKey,
                Topic = topic,
                ExecuteTimestampUtc = futurePublishDate.ToUniversalTime(),
                Message = message
            };

            return _bus.PublishAsync(announcement, topic);
        }

        public Task FuturePublishAsync<T>(TimeSpan messageDelay, T message, string cancellationKey = null) where T : class
        {
            return FuturePublishAsync(messageDelay, message, string.Empty, cancellationKey);
        }

        public Task FuturePublishAsync<T>(TimeSpan messageDelay, T message, string topic, string cancellationKey = null) where T : class
        {
            var futurePublishDate = DateTime.UtcNow.Add(messageDelay);
            return FuturePublishAsync(futurePublishDate, message, topic, cancellationKey);
        }

        public Task CancelFuturePublishAsync(string cancellationKey)
        {
            return _bus.PublishAsync<Cancelation>(new Cancelation { CancellationKey = cancellationKey });
        }


        public void FuturePublish<T>(DateTime futurePublishDate, T message, string cancellationKey = null) where T : class
        {
            FuturePublish(futurePublishDate, message, string.Empty, cancellationKey);
        }

        public void FuturePublish<T>(DateTime futurePublishDate, T message, string topic, string cancellationKey = null) where T : class
        {
            var announcement = new Announcement
            {
                CancellationKey = cancellationKey,
                Topic = topic,
                ExecuteTimestampUtc = futurePublishDate.ToUniversalTime(),
                Message = message
            };
            _bus.Publish(announcement);
        }

        

        public void FuturePublish<T>(TimeSpan messageDelay, T message, string cancellationKey = null) where T : class
        {
            FuturePublish(messageDelay, message, string.Empty, cancellationKey);
        }

        public void FuturePublish<T>(TimeSpan messageDelay, T message, string topic, string cancellationKey = null) where T : class
        {
            var futurePublishDate = DateTime.UtcNow.Add(messageDelay);
            FuturePublish(futurePublishDate, message, topic, cancellationKey);
        }

       
        public void CancelFuturePublish(string cancellationKey)
        {
            _bus.Publish(new Cancelation {CancellationKey = cancellationKey});
        }
    }
}
