using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoPoRcvT
    {
        public KoPoRcvT()
        {
            Baw944s = new HashSet<Baw944>();
            KoPoRcvDs = new HashSet<KoPoRcvD>();
            Way944s = new HashSet<Way944>();
        }

        public int KoRcvTId { get; set; }
        public int PoTId { get; set; }
        public DateTime RcvDate { get; set; }
        public string TplRcvNo { get; set; }
        public string PoNo { get; set; }
        public string ContNo { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual PoT PoT { get; set; }
        public virtual ICollection<Baw944> Baw944s { get; set; }
        public virtual ICollection<KoPoRcvD> KoPoRcvDs { get; set; }
        public virtual ICollection<Way944> Way944s { get; set; }
    }
}
