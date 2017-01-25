using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupApp.Models
{
    public class Result
    {
        public Result()
        {
            RabbitMqState = TestState.Unknown;
            MongoDbState = TestState.Unknown;
        }

        public TestState RabbitMqState { get; set; }

        public TestState MongoDbState { get; set; }
    }
}
