﻿using System;
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
                myBus = RabbitHutch.CreateBus("host=localhost:5672,localhost:5673,localhost:5674");
                myBus.Subscribe<ClusterMessage>("ClusterSub", msg => {
                    Console.WriteLine($"Received from {msg.Host} at {msg.Timestamp}: {msg.Message}");
                });

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
