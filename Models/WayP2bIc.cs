using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayP2bIc
    {
        public WayP2bIc()
        {
            Way846Bs = new HashSet<Way846B>();
            Way846Ps = new HashSet<Way846P>();
            Way850s = new HashSet<Way850>();
            Way855s = new HashSet<Way855>();
            Way856s = new HashSet<Way856>();
            Way860s = new HashSet<Way860>();
            Way865s = new HashSet<Way865>();
            Way943s = new HashSet<Way943>();
            Way944s = new HashSet<Way944>();
            Way945s = new HashSet<Way945>();
        }

        public int IcId { get; set; }
        public int LocationId { get; set; }
        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }

        public virtual ICollection<Way846B> Way846Bs { get; set; }
        public virtual ICollection<Way846P> Way846Ps { get; set; }
        public virtual ICollection<Way850> Way850s { get; set; }
        public virtual ICollection<Way855> Way855s { get; set; }
        public virtual ICollection<Way856> Way856s { get; set; }
        public virtual ICollection<Way860> Way860s { get; set; }
        public virtual ICollection<Way865> Way865s { get; set; }
        public virtual ICollection<Way943> Way943s { get; set; }
        public virtual ICollection<Way944> Way944s { get; set; }
        public virtual ICollection<Way945> Way945s { get; set; }
    }
}
