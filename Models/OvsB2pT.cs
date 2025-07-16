using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class OvsB2pT
    {
        public OvsB2pT()
        {
            Ovs846s = new HashSet<Ovs846>();
            Ovs855s = new HashSet<Ovs855>();
            Ovs856s = new HashSet<Ovs856>();
        }

        public int EdiTsId { get; set; }
        public int EdiIcId { get; set; }

        public virtual OvsB2pIc EdiIc { get; set; }
        public virtual ICollection<Ovs846> Ovs846s { get; set; }
        public virtual ICollection<Ovs855> Ovs855s { get; set; }
        public virtual ICollection<Ovs856> Ovs856s { get; set; }
    }
}
