using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmtB2pIc
    {
        public WmtB2pIc()
        {
            Wmt850s = new HashSet<Wmt850>();
            WmtB2pTs = new HashSet<WmtB2pT>();
        }

        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }
        public byte As2Status { get; set; }

        public virtual ICollection<Wmt850> Wmt850s { get; set; }
        public virtual ICollection<WmtB2pT> WmtB2pTs { get; set; }
    }
}
