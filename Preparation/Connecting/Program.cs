using System;
using EasyNetQ;

namespace FP.Spartakiade2017.MsRmq.Preparation.Connecting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost");
                Console.WriteLine("Verbindung wurde aufgebaut: {0}", myBus.IsConnected);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Verbindung ist fehlgeschlagen");
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