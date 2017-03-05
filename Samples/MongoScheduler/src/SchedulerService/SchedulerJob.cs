using System;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.SchedulerService
{
    public class SchedulerJob
    {
        public DateTime ExecuteTimestampUtc { get; set; }

        public string CancellationKey { get; set; }
    }
}
