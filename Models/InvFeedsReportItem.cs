using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsReportItem
    {
        public InvFeedsReportItem()
        {
            InvFeedsRepItemDetails = new HashSet<InvFeedsRepItemDetail>();
        }

        public long InvFeedsReportItemId { get; set; }
        public int? ItemNoId { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public long? InvFeedsReportId { get; set; }
        public bool? IsSet { get; set; }

        public virtual InvFeedsReport InvFeedsReport { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual Employee LastModifiedByNavigation { get; set; }
        public virtual InvFeedsRepTableDetail InvFeedsRepTableDetail { get; set; }
        public virtual ICollection<InvFeedsRepItemDetail> InvFeedsRepItemDetails { get; set; }
    }
}
