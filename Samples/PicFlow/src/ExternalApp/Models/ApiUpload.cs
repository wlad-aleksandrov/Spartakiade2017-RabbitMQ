using Nancy;

namespace FP.Spartakiade2017.PicFlow.ExternalApp.Models
{
    public class ApiUpload
    {
        public string ApiKey { get; set; }

        public HttpFile Image { get; set; }

        public string Message { get; set; }

        public string User { get; set; }

    }
}
