using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsRuleSkumkt
    {
        public long InvFeedsRuleSkumktId { get; set; }
        public long? InvFeedsRuleSkuid { get; set; }
        public int? CustomerId { get; set; }
        public bool? DoNotFeedToHere { get; set; }
        public int? CustomFixedPercentage { get; set; }
        public int? CustomZeroOutAt { get; set; }
        public bool? CustomRuleForRatioZeroOut { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsPermanent { get; set; }
        public bool? IsActivated { get; set; }

        public virtual InvFeedsRuleSku InvFeedsRuleSku { get; set; }
    }
}
