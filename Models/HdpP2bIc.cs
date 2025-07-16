using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class HdpP2bIc
    {
        public HdpP2bIc()
        {
            Hdp810s = new HashSet<Hdp810>();
            Hdp846s = new HashSet<Hdp846>();
            Hdp850s = new HashSet<Hdp850>();
            Hdp855s = new HashSet<Hdp855>();
            Hdp856s = new HashSet<Hdp856>();
        }

        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiFname { get; set; }

        public virtual ICollection<Hdp810> Hdp810s { get; set; }
        public virtual ICollection<Hdp846> Hdp846s { get; set; }
        public virtual ICollection<Hdp850> Hdp850s { get; set; }
        public virtual ICollection<Hdp855> Hdp855s { get; set; }
        public virtual ICollection<Hdp856> Hdp856s { get; set; }
    }
}
