namespace FP.Spartakiade2017.MsRmq.MongoScheduler.SchedulerService
{
    public class MessageRepository
    {
        private readonly string _mongoConnectionString;

        public MessageRepository(string mongoConnectionString)
        {
            _mongoConnectionString = mongoConnectionString;
        }

        public async Task<string> SaveFutureMessage<T>(T sourceMessage, DateTime executeDatetimeUtc, string topic,
            string cancellationKey)
        {
            if (string.IsNullOrEmpty(cancellationKey))
            {
                cancellationKey = Guid.NewGuid().ToString("N");
            }

            var mongoMessage = new MongoFutureMessage
            {
                CancellationKey = cancellationKey,
                CreateTimestampUtc = DateTime.UtcNow,
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

        public async Task<MongoFutureMessage> GetFutureMessageById(string id)
        {
            var collection = GetMongoDatabase().GetCollection<MongoFutureMessage>("Messages");
            return await collection.Find(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();
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

    }

}
