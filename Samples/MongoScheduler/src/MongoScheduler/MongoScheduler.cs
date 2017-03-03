using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.FluentConfiguration;
using EasyNetQ.Scheduling;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.MongoScheduler
{
    public class MongoScheduler : IScheduler
    {
        private readonly MessageRepository _messageRepository;
        public MongoScheduler(MessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Task FuturePublishAsync<T>(DateTime futurePublishDate, T message, string cancellationKey = null) where T : class
        {
            return FuturePublishAsync(futurePublishDate, message, string.Empty, cancellationKey);
        }

        public async Task FuturePublishAsync<T>(DateTime futurePublishDate, T message, string topic, string cancellationKey = null) where T : class
        {
            var id = await _messageRepository.SaveFutureMessage<T>(message, futurePublishDate, topic, cancellationKey);
            await AnnounceAction(id);
        }

        public void FuturePublish<T>(DateTime futurePublishDate, T message, string cancellationKey = null) where T : class
        {
            FuturePublishAsync(futurePublishDate, message, cancellationKey).Wait();
        }

        public void FuturePublish<T>(DateTime futurePublishDate, T message, string topic, string cancellationKey = null) where T : class
        {
            FuturePublishAsync(futurePublishDate, message, topic, cancellationKey).Wait();
        }

        public Task FuturePublishAsync<T>(TimeSpan messageDelay, T message, string cancellationKey = null) where T : class
        {
            var futurePublishDate = DateTime.UtcNow.Add(messageDelay);
            return FuturePublishAsync(futurePublishDate, message, cancellationKey);
        }

        public Task FuturePublishAsync<T>(TimeSpan messageDelay, T message, string topic, string cancellationKey = null) where T : class
        {
            var futurePublishDate = DateTime.UtcNow.Add(messageDelay);
            return FuturePublishAsync(futurePublishDate, message, topic, cancellationKey);
        }

        public void FuturePublish<T>(TimeSpan messageDelay, T message, string cancellationKey = null) where T : class
        {
            FuturePublishAsync(messageDelay, message, cancellationKey).Wait();
        }

        public void FuturePublish<T>(TimeSpan messageDelay, T message, string topic, string cancellationKey = null) where T : class
        {
            FuturePublishAsync(messageDelay, message, topic, cancellationKey).Wait();
        }

        public Task CancelFuturePublishAsync(string cancellationKey)
        {
            return _messageRepository.CancelMessage(cancellationKey);
        }

        public void CancelFuturePublish(string cancellationKey)
        {
            _messageRepository.CancelMessage(cancellationKey).Wait();
        }

        public Func<string, Task> AnnounceAction { private get; set; }
    }
}
