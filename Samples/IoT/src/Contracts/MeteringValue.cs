using System;

namespace FP.Spartakiade2017.MsRmq.IoTApp.Contracts
{
  
        public class MeteringValue
        {
            public decimal Value { get; set; }

            public string ObisCode { get; set; }

            public DateTime Timestamp { get; set; }

            public string Host { get; set; }
        }
   
}
