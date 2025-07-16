using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvAdjD
    {
        public int InvAdjDId { get; set; }
        public int InvAdjTId { get; set; }
        public int LineId { get; set; }
        public int ItemNoId { get; set; }
        public int LocationId { get; set; }
        public int QtyAdj { get; set; }
        public int NsIntId { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }

        public virtual InvAdjT InvAdjT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
