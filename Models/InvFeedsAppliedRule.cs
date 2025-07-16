using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsAppliedRule
    {
        public InvFeedsAppliedRule()
        {
            InvFeedsRepItemLocs = new HashSet<InvFeedsRepItemLoc>();
        }

        public int InvFeedsAppliedRuleId { get; set; }
        public int? RuleNo { get; set; }
        public string Description { get; set; }

        public virtual ICollection<InvFeedsRepItemLoc> InvFeedsRepItemLocs { get; set; }
    }
}
