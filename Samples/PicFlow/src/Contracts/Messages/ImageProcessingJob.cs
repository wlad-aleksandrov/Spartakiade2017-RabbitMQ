namespace FP.Spartakiade2017.PicFlow.Contracts.Messages
{
    public class ImageProcessingJob : ImageJob
    {
        public string Overlay { get; set; }

        public int Resolution { get; set; }
    }
}
