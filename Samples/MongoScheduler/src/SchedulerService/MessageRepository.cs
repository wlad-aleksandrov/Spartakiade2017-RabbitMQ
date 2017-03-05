using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.SchedulerService
{
    public class MessageRepository
    {
        private readonly string _mongoConnectionString;

        public MessageRepository(string mongoConnectionString)
        {
            _mongoConnectionString = mongoConnectionString;
        }

        public async Task<string> SaveFutureMessage<T>(T sourceMessage, DateTime createTimestampUtc, DateTime executeDatetimeUtc, string topic,
            string cancellationKey)
        {
            var mongoMessage = new MongoFutureMessage
            {
                CancellationKey = cancellationKey,
                CreateTimestampUtc = createTimestampUtc,
                Type = typeof(T).AssemblyQualifiedName,
                Content = sourceMessage,
                ExecuteTimestampUtc = executeDatetimeUtc.ToUniversalTime(),
                Topic = topic,
                State = MongoFutureMessageState.New
            };
            var db = GetMongoDatabase();
            var collection = db.GetCollection<MongoFutureMessage>("Messages");
            await collection.InsertOneAsync(mongoMessage);

            return mongoMessage.Id.ToString();
        }

        public MongoFutureMessage GetFutureMessageById(string id)
        {
            var collection = GetMongoDatabase().GetCollection<MongoFutureMessage>("Messages");
            return collection.Find(x => x.Id == new ObjectId(id)).FirstOrDefault();
        }

        public async Task CancelMessage(string cancellationKey)
        {
            var collection = GetMongoDatabase().GetCollection<MongoFutureMessage>("Messages");
            await collection.FindOneAndUpdateAsync(x => x.CancellationKey == cancellationKey,
                Builders<MongoFutureMessage>.Update.Set("state", MongoFutureMessageState.Canceled));
        }

        private IMongoDatabase GetMongoDatabase()
        {
            var client = new MongoClient(_mongoConnectionString);
            return client.GetDatabase("RabbitMQ");
        }

        public void UpdateState(string id, MongoFutureMessageState state)
        {
            var collection = GetMongoDatabase().GetCollection<MongoFutureMessage>("Messages");
            collection.FindOneAndUpdate(x => x.Id == new ObjectId(id),
                Builders<MongoFutureMessage>.Update.Set("state", state));
        }

        public IEnumerable<MongoFutureMessage> GetActiveMessages()
        {
            var collection = GetMongoDatabase().GetCollection<MongoFutureMessage>("Messages");
            return collection.FindSync(x => x.State == MongoFutureMessageState.New).Current;
        }
    }

}
