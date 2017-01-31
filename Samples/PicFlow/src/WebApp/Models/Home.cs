using System.Collections.Generic;

namespace FP.Spartakiade2017.PicFlow.WebApp.Models
{
    public class Home
    {
        public Home()
        {
            Jobs = new List<ProcessingJob>();
        }

        public string Message { get; set; }

        public List<ProcessingJob> Jobs { get; set; }
    }
}
