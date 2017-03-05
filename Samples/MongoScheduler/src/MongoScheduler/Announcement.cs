using System;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.MongoScheduler
{
    public class Announcement
    {
        public object Message { get; set; }

        public DateTime ExecuteTimestampUtc { get; set; }

        public DateTime CreateTimestampUtc { get; set; }

        public string Topic { get; set; }

        public string CancellationKey { get; set; }

    }
}
