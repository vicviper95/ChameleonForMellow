using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsRepItemLoc
    {
        public long InvFeedsRepItemLocId { get; set; }
        public long? InvFeedsRepItemDetailId { get; set; }
        public int? LocationId { get; set; }
        public int? QtyAvail { get; set; }
        public int? QtyOnBackOrder { get; set; }
        public int? InvFeedsAppliedRuleId { get; set; }
        public int? Ratio { get; set; }
        public int? StagePoqty { get; set; }

        public virtual InvFeedsAppliedRule InvFeedsAppliedRule { get; set; }
        public virtual InvFeedsRepItemDetail InvFeedsRepItemDetail { get; set; }
    }
}
