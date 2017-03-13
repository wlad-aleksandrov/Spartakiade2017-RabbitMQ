using System;
using EasyNetQ;
using FP.Spartakiade2017.MsRmq.Cluster.Contracts;

namespace FP.Spartakiade2017.MsRmq.Cluster.Display
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                
                Console.WriteLine("Display started");
                Console.ReadLine();
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
    }
}
