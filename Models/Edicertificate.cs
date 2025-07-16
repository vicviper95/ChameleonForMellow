using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Edicertificate
    {
        public Edicertificate()
        {
            Edipartners = new HashSet<Edipartner>();
        }

        public int CertificateId { get; set; }
        public int? MyInfoId { get; set; }
        public int? PartnerId { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public string SignAlgorithm { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Filename { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual EdimyInfo MyInfo { get; set; }
        public virtual Edipartner Partner { get; set; }
        public virtual ICollection<Edipartner> Edipartners { get; set; }
    }
}
