using System;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.Contracts
{

    public class FutureMessage
    {
        public FutureMessage()
        {
            Timestamp = DateTime.Now;
        }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
