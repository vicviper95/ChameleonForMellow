using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsRule
    {
        public int InvFeedRuleId { get; set; }
        public int? CustomerId { get; set; }
        public int? ZeroOutAt { get; set; }
        public int? CustomFeedRatio { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public bool? IsActivated { get; set; }
        public int? RatioOnLowData { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee LastModifiedByNavigation { get; set; }
    }
}
