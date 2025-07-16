using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MkInvFeedT
    {
        public MkInvFeedT()
        {
            EdiTs = new HashSet<EdiT>();
            MkInvFeedDs = new HashSet<MkInvFeedD>();
        }

        public int InvFeedTId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime? TimeSent { get; set; }
        public int? EmpSentId { get; set; }
        public DateTime FeedDate { get; set; }
        public int? EmpCheckId { get; set; }
        public DateTime? TimeAdded { get; set; }
        public int? EmpAddedId { get; set; }
        public bool? IsFullFeed { get; set; }
        public long? InvtFeedsReportId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee EmpCheck { get; set; }
        public virtual Employee EmpSent { get; set; }
        public virtual InvFeedsReport InvtFeedsReport { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<MkInvFeedD> MkInvFeedDs { get; set; }
    }
}
