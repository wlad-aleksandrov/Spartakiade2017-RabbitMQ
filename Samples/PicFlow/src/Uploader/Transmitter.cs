using System;
using System.Net.Http;
using System.Threading.Tasks;
using EasyNetQ;
using FP.Spartakiade2017.PicFlow.Contracts.Dto;
using FP.Spartakiade2017.PicFlow.Contracts.FileHandler;
using FP.Spartakiade2017.PicFlow.Contracts.Messages;

namespace FP.Spartakiade2017.PicFlow.Uploader
{
    public class Transmitter : IDisposable
    {
        private readonly string _mongoConnectionString;
        private IDisposable _subscription;
        private readonly string _externalAppUrl;

        public Transmitter( string mongoConnectionstring, string externalAppUrl)
        {
            _mongoConnectionString = mongoConnectionstring;
            _externalAppUrl = externalAppUrl;
        }

        public void Init()
        {
            // TODO: Subscription für Uploads
        }

        private async Task UploadImage(ImageUploadJob job)
        {

            var handler = new MongoDbFileHandler(_mongoConnectionString);
            var image = await handler.GetMessageObject<DtoImage>(job.Id);

            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(job.User), "User");
                content.Add(new StringContent(job.Message), "Message");
                content.Add(new StringContent("sparta2017"), "APIKEY");
                content.Add(new ByteArrayContent(image.Data), "Image", image.FileName);
                await client.PostAsync(_externalAppUrl, content);
            }

        }

        public void Dispose()
        {
            // TODO: Aufräumen
        }
    }
}
