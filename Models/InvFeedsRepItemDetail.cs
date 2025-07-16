using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsRepItemDetail
    {
        public InvFeedsRepItemDetail()
        {
            InvFeedsRepItemLocs = new HashSet<InvFeedsRepItemLoc>();
        }

        public long InvFeedsRepItemDetailId { get; set; }
        public int? CustomerId { get; set; }
        public int? Ratio { get; set; }
        public long? InvFeedsReportItemId { get; set; }
        public int? DuplicateCounter { get; set; }
        public int? CustomerWarehouseQty { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual InvFeedsReportItem InvFeedsReportItem { get; set; }
        public virtual ICollection<InvFeedsRepItemLoc> InvFeedsRepItemLocs { get; set; }
    }
}
