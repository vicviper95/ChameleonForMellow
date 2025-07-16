using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class OvsB2pIc
    {
        public OvsB2pIc()
        {
            Ovs850s = new HashSet<Ovs850>();
            Ovs860s = new HashSet<Ovs860>();
            OvsB2pTs = new HashSet<OvsB2pT>();
        }

        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }
        public byte As2Status { get; set; }

        public virtual ICollection<Ovs850> Ovs850s { get; set; }
        public virtual ICollection<Ovs860> Ovs860s { get; set; }
        public virtual ICollection<OvsB2pT> OvsB2pTs { get; set; }
    }
}
