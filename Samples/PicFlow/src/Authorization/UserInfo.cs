using System;

namespace FP.Spartakiade2017.PicFlow.Authorization
{
    public class UserInfo
    {
        public bool IsValid { get; set; }

        public string User { get; set; }

        public Guid Id { get; set; }
    }
}
