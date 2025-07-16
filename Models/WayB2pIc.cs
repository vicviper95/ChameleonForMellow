using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayB2pIc
    {
        public WayB2pIc()
        {
            Way846Ps = new HashSet<Way846P>();
            Way850s = new HashSet<Way850>();
            Way860s = new HashSet<Way860>();
            Way943s = new HashSet<Way943>();
            Way944s = new HashSet<Way944>();
            Way945s = new HashSet<Way945>();
            WayB2pTs = new HashSet<WayB2pT>();
        }

        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }
        public byte As2Status { get; set; }

        public virtual ICollection<Way846P> Way846Ps { get; set; }
        public virtual ICollection<Way850> Way850s { get; set; }
        public virtual ICollection<Way860> Way860s { get; set; }
        public virtual ICollection<Way943> Way943s { get; set; }
        public virtual ICollection<Way944> Way944s { get; set; }
        public virtual ICollection<Way945> Way945s { get; set; }
        public virtual ICollection<WayB2pT> WayB2pTs { get; set; }
    }
}
