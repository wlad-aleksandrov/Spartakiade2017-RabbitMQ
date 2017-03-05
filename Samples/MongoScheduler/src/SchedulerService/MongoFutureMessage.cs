using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.SchedulerService
{
    public class MongoFutureMessage
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("createtimestamp")]
        public DateTime CreateTimestampUtc { get; set; }

        [BsonElement("excutetimestamp")]
        public DateTime ExecuteTimestampUtc { get; set; }

        [BsonElement("topic")]
        public string Topic { get; set; }

        [BsonElement("content")]
        public object Content { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("cancellationkey")]
        public string CancellationKey { get; set; }

        [BsonElement("state")]
        public MongoFutureMessageState State { get; set; }
    }
}
