using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsItem
    {
        public InvFeedsItem()
        {
            InvFeedsItemLocQties = new HashSet<InvFeedsItemLocQty>();
        }

        public long InvFeedsItemId { get; set; }
        public int? ItemNoId { get; set; }
        public long? InvFeedsReportId { get; set; }
        public bool? IsSet { get; set; }

        public virtual InvFeedsReport InvFeedsReport { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual ICollection<InvFeedsItemLocQty> InvFeedsItemLocQties { get; set; }
    }
}
