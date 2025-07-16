using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsSkuconflictReport
    {
        public InvFeedsSkuconflictReport()
        {
            InvFeedsSkucnflctRepItems = new HashSet<InvFeedsSkucnflctRepItem>();
        }

        public long InvFeedsSkuconflictReportId { get; set; }
        public DateTime? ImportedDate { get; set; }
        public int? ImportedBy { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee ImportedByNavigation { get; set; }
        public virtual ICollection<InvFeedsSkucnflctRepItem> InvFeedsSkucnflctRepItems { get; set; }
    }
}
