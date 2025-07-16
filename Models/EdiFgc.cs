using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiFgc
    {
        public EdiFgc()
        {
            EdiAutoMks = new HashSet<EdiAutoMk>();
            EdiAutoTpls = new HashSet<EdiAutoTpl>();
            EdiIcM2ps = new HashSet<EdiIcM2p>();
            EdiIcP2ms = new HashSet<EdiIcP2m>();
            EdiTs = new HashSet<EdiT>();
        }

        public byte FgcId { get; set; }
        public int Fgc { get; set; }
        public string FgcStr { get; set; }
        public string FgcDesc { get; set; }
        public bool IsTpl { get; set; }
        public bool IsMarket { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EdiAutoMk> EdiAutoMks { get; set; }
        public virtual ICollection<EdiAutoTpl> EdiAutoTpls { get; set; }
        public virtual ICollection<EdiIcM2p> EdiIcM2ps { get; set; }
        public virtual ICollection<EdiIcP2m> EdiIcP2ms { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
    }
}
