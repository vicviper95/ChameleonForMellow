using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CsInvtFeedT
    {
        public CsInvtFeedT()
        {
            CsInvtFeedDs = new HashSet<CsInvtFeedD>();
        }

        public int CsInvtFeedTId { get; set; }
        public int CustomerId { get; set; }
        public int EmpAddedId { get; set; }
        public int? EmpReviewdId { get; set; }
        public int? EmpSentId { get; set; }
        public DateTime TimeAdded { get; set; }
        public DateTime? TimeReviewed { get; set; }
        public DateTime? TimeSent { get; set; }
        public bool IsReviewded { get; set; }
        public string Note { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee EmpAdded { get; set; }
        public virtual Employee EmpReviewd { get; set; }
        public virtual Employee EmpSent { get; set; }
        public virtual ICollection<CsInvtFeedD> CsInvtFeedDs { get; set; }
    }
}
