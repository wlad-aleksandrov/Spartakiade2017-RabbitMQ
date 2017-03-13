using System;
using System.Collections.Generic;
using System.Net.Security;
using EasyNetQ;
using FP.Spartakiade2017.MsRmq.IoTApp.Contracts;

namespace FP.Spartakiade2017.MsRmq.IoTApp.Hub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            try
            {
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                myBus?.Dispose();
            }
        }
    }
}
