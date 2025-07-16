using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class OvsP2bIc
    {
        public OvsP2bIc()
        {
            Ovs846s = new HashSet<Ovs846>();
            Ovs850s = new HashSet<Ovs850>();
            Ovs855s = new HashSet<Ovs855>();
            Ovs856s = new HashSet<Ovs856>();
            Ovs860s = new HashSet<Ovs860>();
        }

        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }

        public virtual ICollection<Ovs846> Ovs846s { get; set; }
        public virtual ICollection<Ovs850> Ovs850s { get; set; }
        public virtual ICollection<Ovs855> Ovs855s { get; set; }
        public virtual ICollection<Ovs856> Ovs856s { get; set; }
        public virtual ICollection<Ovs860> Ovs860s { get; set; }
    }
}
