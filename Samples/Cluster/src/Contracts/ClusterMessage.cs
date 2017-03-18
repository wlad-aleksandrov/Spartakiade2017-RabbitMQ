using System;

namespace FP.Spartakiade2017.MsRmq.Cluster.Contracts
{
    public class ClusterMessage
    {
        public string Message { get; set; }

        public string Host { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
