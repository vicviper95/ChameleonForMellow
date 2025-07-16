using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiIcM2p
    {
        public EdiIcM2p()
        {
            EdiTs = new HashSet<EdiT>();
        }

        public int MyIcId { get; set; }
        public int EpId { get; set; }
        public byte FgcId { get; set; }
        public DateTime IcTime { get; set; }
        public string EdiFname { get; set; }
        public string EdiFileId { get; set; }
        public int? IcNoOld { get; set; }
        public byte Status { get; set; }

        public virtual Edipartner Ep { get; set; }
        public virtual EdiFgc Fgc { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
    }
}
