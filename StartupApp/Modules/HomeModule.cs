using System;
using EasyNetQ;
using MongoDB.Bson;
using MongoDB.Driver;
using Nancy;
using StartupApp.Models;

namespace StartupApp.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/", true] = async (x, ct) =>
            {
                var model = new Result();
                try
                {
                    using (var myBus = RabbitHutch.CreateBus("host=rabbitmq"))
                    {
                        if (myBus.IsConnected)
                        {
                            model.RabbitMqState = TestState.Successful;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    model.RabbitMqState = TestState.Failed;
                }

                try
                {
                    var mongoSettings = new MongoClientSettings
                    {
                        ConnectTimeout = TimeSpan.FromSeconds(5),
                        Server = MongoServerAddress.Parse("mongo:27017")
                    };

                    var client = new MongoClient(mongoSettings);


                    var db = client.GetDatabase("MessagingServerDB");
                    var mongotest = await db.RunCommandAsync((Command<BsonDocument>)"{ping:1}");

                    model.MongoDbState = TestState.Successful;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    model.MongoDbState = TestState.Failed;
                }

                return View["Home", model];

            };
        }
    }
}
