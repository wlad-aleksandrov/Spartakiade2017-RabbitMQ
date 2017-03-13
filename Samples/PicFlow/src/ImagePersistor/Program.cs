using System;
using System.Threading;
using EasyNetQ;
using FP.Spartakiade2017.PicFlow.Contracts;
using FP.Spartakiade2017.PicFlow.Contracts.Messages;

namespace FP.Spartakiade2017.PicFlow.ImagePersistor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbCnn = EnvironmentVariable.GetValueOrDefault("ConnectionStringImageDB",
                "host=localhost;database=spartakiade;password=sportfrei;username=spartakiade");
            var mongoCnn = EnvironmentVariable.GetValueOrDefault("ConnectionStringDocumentDB", "mongodb://localhost");
            var rabbitCnn = EnvironmentVariable.GetValueOrDefault("ConnectionStringRabbitMQ", "host=localhost");

            IBus myBus = null;
            try
            {
                // TODO: Speicher - Anfragen annehmen 
                
                // Bild speichern
                //var dbWriter = new DbWriter(mongoCnn, dbCnn);
                //await dbWriter.PersistImage(...);

                Console.WriteLine("ImagePersistor gestartet...");
                while (Console.ReadLine() != "quit") { Thread.Sleep(int.MaxValue); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ImagePersistor - Verbindung ist fehlgeschlagen");
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }

            Console.WriteLine("ImagePersistor beendet...");
        }
    }
}
