using System;
using System.Collections.Generic;
using System.Net.Security;
using EasyNetQ;
using FP.Spartakiade2017.MsRmq.IoTApp.Contracts;

namespace FP.Spartakiade2017.MsRmq.IoTApp.Device
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            Console.WriteLine("IoT Device is starting");
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                myBus?.Dispose();
            }
            Console.ReadLine();

        }
    }
}
