using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmtB2pT
    {
        public WmtB2pT()
        {
            Wmt846s = new HashSet<Wmt846>();
            Wmt855s = new HashSet<Wmt855>();
            Wmt856s = new HashSet<Wmt856>();
        }

        public int EdiTsId { get; set; }
        public int EdiIcId { get; set; }

        public virtual WmtB2pIc EdiIc { get; set; }
        public virtual ICollection<Wmt846> Wmt846s { get; set; }
        public virtual ICollection<Wmt855> Wmt855s { get; set; }
        public virtual ICollection<Wmt856> Wmt856s { get; set; }
    }
}
