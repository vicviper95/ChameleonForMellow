using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PtAs2Cert
    {
        public int As2CertId { get; set; }
        public int EpId { get; set; }
        public string FileName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public DateTime AddedTime { get; set; }
        public string EdiUsage { get; set; }

        public virtual EdiPatrnerInfo Ep { get; set; }
    }
}
