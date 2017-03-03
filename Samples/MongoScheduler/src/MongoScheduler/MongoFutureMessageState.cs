using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.MongoScheduler
{
    public enum MongoFutureMessageState
    {
        None = 0,
        New = 1,
        Done = 2,
        Error = 4,
        Canceled = 5
    }
}
