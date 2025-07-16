using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsRulePerSkuXxx
    {
        public int InvFeedRulePerSkuid { get; set; }
        public int ItemNoId { get; set; }
        public int CustomerSkuid { get; set; }
        public int? ChanZeroOutAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public byte[] LastModifiedTime { get; set; }
        public bool? DoNotFeedToAll { get; set; }
    }
}
