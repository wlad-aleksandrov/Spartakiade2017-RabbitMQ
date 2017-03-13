using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using EasyNetQ;
using EasyNetQ.NonGeneric;

namespace FP.Spartakiade2017.MsRmq.MongoScheduler.SchedulerService
{
    public class Scheduler : IDisposable
    {
        private IBus _bus;
        private MessageRepository _messageRepository;
        private readonly Timer _timer;
        private readonly ConcurrentDictionary<string, SchedulerJob> _jobs = new ConcurrentDictionary<string, SchedulerJob>();
        private bool _isRunning = false;
        private static bool _isExecute = false;

        

        public Scheduler(IBus bus, MessageRepository messageRepository)
        {
            _bus = bus;
            _messageRepository = messageRepository;
            _timer = new Timer(state => ExecuteDueJobs(), null, Timeout.Infinite, Timeout.Infinite);
        }

       

        public void Run()
        {
            _isRunning = true;
            UpdateTimer();
        }

        public void Stop()
        {
            _isRunning = false;
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            if (_isRunning && !_isExecute && _jobs.Any())
            {
                _timer.Change(0, 1000);
            }
            else
            {
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        private void ExecuteDueJobs()
        {
            try
            {
                _isExecute = true;
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
                var utcNow = DateTime.UtcNow;
                var jobsToExecute = _jobs.Where(x => x.Value.ExecuteTimestampUtc <= utcNow).ToArray();
                foreach (var job in jobsToExecute)
                {
                    try
                    {
                        var mongoMsg = _messageRepository.GetFutureMessageById(job.Key);

                        // Nachrichten übergeben

                        _jobs.Remove(job.Key);
                        _messageRepository.UpdateState(job.Key, MongoFutureMessageState.Done);
                    }
                    catch (Exception exception)
                    {
                        _jobs.Remove(job.Key);
                        _messageRepository.UpdateState(job.Key, MongoFutureMessageState.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in execute job {ex}");

            }
            finally
            {
                _isExecute = false;
                UpdateTimer();
            }
            
        }

        public void AddJob(string messageId, string cancelationKey, DateTime executeTimestampUtc)
        {
            var job = new SchedulerJob
            {
                ExecuteTimestampUtc = executeTimestampUtc,
                CancellationKey = cancelationKey
            };
            _jobs.AddOrUpdate(messageId, job, (s, j) => job);
            UpdateTimer();
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public void CancelJob(string cancellationKey)
        {
            if (string.IsNullOrEmpty(cancellationKey)) return;

            while (_isExecute)
            {
                Thread.Sleep(250);
            }
            var jobsToCancel = _jobs.Where(x => x.Value.CancellationKey == cancellationKey).ToArray();
            foreach (var job in jobsToCancel)
            {
                _jobs.Remove(job.Key);
            }
        }
    }
}
