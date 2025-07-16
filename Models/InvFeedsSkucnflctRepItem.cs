using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsSkucnflctRepItem
    {
        public long InvFeedsSkucnflctRepItemId { get; set; }
        public long? InvFeedsSkuconflictReportId { get; set; }
        public int? ItemNoId { get; set; }
        public string CustSku { get; set; }
        public string Asin { get; set; }
        public bool? IsResolved { get; set; }
        public int? InvFeedsConflictTypeId { get; set; }
        public string Description { get; set; }

        public virtual InvFeedsConflictType InvFeedsConflictType { get; set; }
        public virtual InvFeedsSkuconflictReport InvFeedsSkuconflictReport { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
