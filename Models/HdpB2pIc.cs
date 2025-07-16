using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class HdpB2pIc
    {
        public HdpB2pIc()
        {
            Hdp850s = new HashSet<Hdp850>();
            HdpB2pTs = new HashSet<HdpB2pT>();
        }

        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }
        public byte As2Status { get; set; }

        public virtual ICollection<Hdp850> Hdp850s { get; set; }
        public virtual ICollection<HdpB2pT> HdpB2pTs { get; set; }
    }
}
