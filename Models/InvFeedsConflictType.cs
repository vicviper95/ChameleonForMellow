using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsConflictType
    {
        public InvFeedsConflictType()
        {
            InvFeedsSkucnflctRepItems = new HashSet<InvFeedsSkucnflctRepItem>();
        }

        public int InvFeedsConflictTypeId { get; set; }
        public string Description { get; set; }
        public int? RuleNo { get; set; }

        public virtual ICollection<InvFeedsSkucnflctRepItem> InvFeedsSkucnflctRepItems { get; set; }
    }
}
