using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayB2pT
    {
        public WayB2pT()
        {
            Way846Bs = new HashSet<Way846B>();
            Way855s = new HashSet<Way855>();
            Way856s = new HashSet<Way856>();
            Way865s = new HashSet<Way865>();
        }

        public int EdiTsId { get; set; }
        public int EdiIcId { get; set; }

        public virtual WayB2pIc EdiIc { get; set; }
        public virtual ICollection<Way846B> Way846Bs { get; set; }
        public virtual ICollection<Way855> Way855s { get; set; }
        public virtual ICollection<Way856> Way856s { get; set; }
        public virtual ICollection<Way865> Way865s { get; set; }
    }
}
