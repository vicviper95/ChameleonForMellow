using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdimyInfo
    {
        public EdimyInfo()
        {
            Edicertificates = new HashSet<Edicertificate>();
        }

        public int MyInfoId { get; set; }
        public string Name { get; set; }
        public string As2id { get; set; }
        public string Url { get; set; }
        public string Isa { get; set; }
        public string Qualifier { get; set; }
        public bool IsSignature { get; set; }
        public bool IsEncrypt { get; set; }
        public bool IsMdn { get; set; }
        public bool IsSandbox { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public bool IsOnPause { get; set; }

        public virtual ICollection<Edicertificate> Edicertificates { get; set; }
    }
}
