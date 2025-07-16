using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TgtB2pT
    {
        public TgtB2pT()
        {
            Tgt846s = new HashSet<Tgt846>();
            Tgt855s = new HashSet<Tgt855>();
            Tgt856s = new HashSet<Tgt856>();
            Tgt865s = new HashSet<Tgt865>();
        }

        public int EdiTsId { get; set; }
        public int EdiIcId { get; set; }

        public virtual TgtB2pIc EdiIc { get; set; }
        public virtual ICollection<Tgt846> Tgt846s { get; set; }
        public virtual ICollection<Tgt855> Tgt855s { get; set; }
        public virtual ICollection<Tgt856> Tgt856s { get; set; }
        public virtual ICollection<Tgt865> Tgt865s { get; set; }
    }
}
