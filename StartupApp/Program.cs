using System;
using System.Threading;
using Nancy;
using Nancy.Hosting.Self;

namespace StartupApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:18317")))
            {
                StaticConfiguration.DisableErrorTraces = false;
                host.Start();

                while (Console.ReadLine() != "quit") { Thread.Sleep(Int32.MaxValue); }
            }
        }
    }
}
