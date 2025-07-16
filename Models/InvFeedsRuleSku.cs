using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsRuleSku
    {
        public InvFeedsRuleSku()
        {
            InvFeedsRuleSkumkts = new HashSet<InvFeedsRuleSkumkt>();
        }

        public long InvFeedsRuleSkuid { get; set; }
        public int? ItemNoId { get; set; }
        public bool? DoNotFeedFromMainsl { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? DoNotFeedFromBanc { get; set; }
        public bool? DoNotFeedFromBasc { get; set; }
        public bool? DoNotFeedFromSwcaft { get; set; }
        public bool? DoNotFeedFromPrismCast { get; set; }
        public bool? DoNotFeedFromPrismCalt { get; set; }
        public bool? DoNotFeedFromZinusTracy { get; set; }
        public bool? DoNotFeedFromZinusChs { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual ICollection<InvFeedsRuleSkumkt> InvFeedsRuleSkumkts { get; set; }
    }
}
