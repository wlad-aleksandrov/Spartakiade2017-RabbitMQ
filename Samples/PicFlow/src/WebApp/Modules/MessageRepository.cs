using System.Threading.Tasks;
using EasyNetQ;
using FP.Spartakiade2017.PicFlow.Contracts.Messages;

namespace FP.Spartakiade2017.PicFlow.WebApp.Modules
{
    public class MessageRepository
    {
        public MessageRepository()
        {

        }

        public Task SendImageProcessingJob(ImageProcessingJob job)
        {
            // TODO: Verarbeitungsanfrage senden
            return null;
        }

        public Task SendUploadJob(ImageUploadJob job)
        {
            // TODO: Upload-Anfrage senden
            return null;
        }
    }
}
