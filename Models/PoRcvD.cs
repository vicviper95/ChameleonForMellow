using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoRcvD
    {
        public int RcvDId { get; set; }
        public int? NsIntId { get; set; }
        public int RcvTId { get; set; }
        public int PoDId { get; set; }
        public int QtyRcvd { get; set; }
        public DateTime? AddedDate { get; set; }
        public int RcvLineNo { get; set; }
        public int? QtyOrdered { get; set; }
        public decimal UnitCost { get; set; }
        public decimal LineTotal { get; set; }
        public int? LocationId { get; set; }
        public bool? IsValid { get; set; }

        public virtual BpmLocation Location { get; set; }
        public virtual PoD PoD { get; set; }
        public virtual PoRcvT RcvT { get; set; }
    }
}
