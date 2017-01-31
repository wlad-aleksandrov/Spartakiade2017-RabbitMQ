using System;

namespace FP.Spartakiade2017.PicFlow.Contracts.Dto
{
    public class DtoImage
    {
        public byte[] Data { get; set; }

        public string FileName { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
