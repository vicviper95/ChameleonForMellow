using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TgtP2bIc
    {
        public TgtP2bIc()
        {
            Tgt846s = new HashSet<Tgt846>();
            Tgt850s = new HashSet<Tgt850>();
            Tgt855s = new HashSet<Tgt855>();
            Tgt856s = new HashSet<Tgt856>();
            Tgt860s = new HashSet<Tgt860>();
            Tgt865s = new HashSet<Tgt865>();
        }

        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiFname { get; set; }

        public virtual ICollection<Tgt846> Tgt846s { get; set; }
        public virtual ICollection<Tgt850> Tgt850s { get; set; }
        public virtual ICollection<Tgt855> Tgt855s { get; set; }
        public virtual ICollection<Tgt856> Tgt856s { get; set; }
        public virtual ICollection<Tgt860> Tgt860s { get; set; }
        public virtual ICollection<Tgt865> Tgt865s { get; set; }
    }
}
