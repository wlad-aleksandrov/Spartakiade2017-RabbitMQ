using System;

namespace FP.Spartakiade2017.PicFlow.Contracts.Dbo
{
    public class Image
    {
        public Guid Id { get; set; }

        public Byte[] Data { get; set; }

        public int Resolution { get; set; }
    }
}
