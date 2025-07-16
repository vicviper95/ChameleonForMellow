using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Edicertification
    {
        public int CertificationId { get; set; }
        public int? EdimyInfoId { get; set; }
        public int? EdipartnerId { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public string Sha { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Filename { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual EdimyInfo EdimyInfo { get; set; }
        public virtual Edipartner Edipartner { get; set; }
    }
}
