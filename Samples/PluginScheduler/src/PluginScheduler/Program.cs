using System;
using EasyNetQ;
using EasyNetQ.Scheduling;

namespace FP.Spartakiade2017.MsRmq.PluginScheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }
            Console.ReadLine();
        }

        private static void StartSubscription(IBus myBus)
        {
            
           
        }

        private static void ScheduleMessage(IBus myBus)
        {
            

        }
    }
}
