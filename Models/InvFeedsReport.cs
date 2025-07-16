using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsReport
    {
        public InvFeedsReport()
        {
            InvFeedsItems = new HashSet<InvFeedsItem>();
            InvFeedsRepTableDetails = new HashSet<InvFeedsRepTableDetail>();
            InvFeedsReportItems = new HashSet<InvFeedsReportItem>();
            MkInvFeedTs = new HashSet<MkInvFeedT>();
        }

        public long InvFeedsReportId { get; set; }
        public DateTime? FeedingDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public bool? IsApproved { get; set; }
        public int? ApprovedBy { get; set; }
        public long? RealTimeInvUpdateId { get; set; }
        public bool? HasSentToEdi { get; set; }

        public virtual Employee ApprovedByNavigation { get; set; }
        public virtual Employee CreatedByNavigation { get; set; }
        public virtual ICollection<InvFeedsItem> InvFeedsItems { get; set; }
        public virtual ICollection<InvFeedsRepTableDetail> InvFeedsRepTableDetails { get; set; }
        public virtual ICollection<InvFeedsReportItem> InvFeedsReportItems { get; set; }
        public virtual ICollection<MkInvFeedT> MkInvFeedTs { get; set; }
    }
}
