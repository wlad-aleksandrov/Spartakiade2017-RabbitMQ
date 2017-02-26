using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ.Scheduling;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.MongoScheduler
{
    public class MongoScheduler : IScheduler
    {
        public Task FuturePublishAsync<T>(DateTime futurePublishDate, T message, string cancellationKey = null) where T : class
        {
            throw new NotImplementedException();
        }

        public Task FuturePublishAsync<T>(DateTime futurePublishDate, T message, string topic, string cancellationKey = null) where T : class
        {
            throw new NotImplementedException();
        }

        public void FuturePublish<T>(DateTime futurePublishDate, T message, string cancellationKey = null) where T : class
        {
            throw new NotImplementedException();
        }

        public void FuturePublish<T>(DateTime futurePublishDate, T message, string topic, string cancellationKey = null) where T : class
        {
            throw new NotImplementedException();
        }

        public Task FuturePublishAsync<T>(TimeSpan messageDelay, T message, string cancellationKey = null) where T : class
        {
            throw new NotImplementedException();
        }

        public Task FuturePublishAsync<T>(TimeSpan messageDelay, T message, string topic, string cancellationKey = null) where T : class
        {
            throw new NotImplementedException();
        }

        public void FuturePublish<T>(TimeSpan messageDelay, T message, string cancellationKey = null) where T : class
        {
            throw new NotImplementedException();
        }

        public void FuturePublish<T>(TimeSpan messageDelay, T message, string topic, string cancellationKey = null) where T : class
        {
            throw new NotImplementedException();
        }

        public Task CancelFuturePublishAsync(string cancellationKey)
        {
            throw new NotImplementedException();
        }

        public void CancelFuturePublish(string cancellationKey)
        {
            throw new NotImplementedException();
        }
    }
}
