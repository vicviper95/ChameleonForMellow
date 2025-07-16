using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiIcP2m
    {
        public EdiIcP2m()
        {
            EdiTs = new HashSet<EdiT>();
        }

        public int EpIcId { get; set; }
        public int EpId { get; set; }
        public byte FgcId { get; set; }
        public int EpIcNo { get; set; }
        public DateTime IcTime { get; set; }
        public string EdiFname { get; set; }
        public string EdiFileId { get; set; }
        public int? DateKey { get; set; }

        public virtual Edipartner Ep { get; set; }
        public virtual EdiFgc Fgc { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
    }
}
