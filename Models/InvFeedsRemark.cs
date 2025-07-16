using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsRemark
    {
        public long InvFeedsRemarkId { get; set; }
        public int? ItemNoId { get; set; }
        public long? InvFeedsRmrkCtgryId { get; set; }
        public bool? IsActivated { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedBy { get; set; }

        public virtual InvFeedsRmrkCtgry InvFeedsRmrkCtgry { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual Employee LastModifiedByNavigation { get; set; }
    }
}
