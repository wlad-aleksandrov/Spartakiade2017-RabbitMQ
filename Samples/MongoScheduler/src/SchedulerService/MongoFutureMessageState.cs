namespace FP.Spartakiade2017.MsRmq.MongoScheduler.SchedulerService
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
