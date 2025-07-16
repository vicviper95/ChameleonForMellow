using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsItemLocQty
    {
        public long InvFeedsItemLocQtyId { get; set; }
        public long InvFeedsItemId { get; set; }
        public int ItemLocId { get; set; }
        public int? QtyOnHand { get; set; }
        public int? QtyAvail { get; set; }
        public int? StagePoqtyOrig { get; set; }
        public int? StagePoqtyModified { get; set; }
        public int? StagePoqty60 { get; set; }
        public int? StagePoqty90 { get; set; }

        public virtual InvFeedsItem InvFeedsItem { get; set; }
        public virtual BpmLocation ItemLoc { get; set; }
    }
}
