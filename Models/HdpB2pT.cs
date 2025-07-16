using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class HdpB2pT
    {
        public HdpB2pT()
        {
            Hdp810s = new HashSet<Hdp810>();
            Hdp846s = new HashSet<Hdp846>();
            Hdp855s = new HashSet<Hdp855>();
            Hdp856s = new HashSet<Hdp856>();
        }

        public int EdiTsId { get; set; }
        public int EdiIcId { get; set; }

        public virtual HdpB2pIc EdiIc { get; set; }
        public virtual ICollection<Hdp810> Hdp810s { get; set; }
        public virtual ICollection<Hdp846> Hdp846s { get; set; }
        public virtual ICollection<Hdp855> Hdp855s { get; set; }
        public virtual ICollection<Hdp856> Hdp856s { get; set; }
    }
}
