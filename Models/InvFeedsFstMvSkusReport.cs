using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsFstMvSkusReport
    {
        public InvFeedsFstMvSkusReport()
        {
            InvFeedsFstMvRepDetails = new HashSet<InvFeedsFstMvRepDetail>();
        }

        public int FstMvSkusRepId { get; set; }
        public long? InvFeedsReportId { get; set; }
        public DateTime? ReportDate { get; set; }
        public string ReportedBy { get; set; }
        public int? ReportedById { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<InvFeedsFstMvRepDetail> InvFeedsFstMvRepDetails { get; set; }
    }
}
