using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RemitFee
    {
        public RemitFee()
        {
            RemitCmDs = new HashSet<RemitCmD>();
        }

        public int RemitFeeId { get; set; }
        public int RemitId { get; set; }
        public string Name { get; set; }
        public int? FeeTypeId { get; set; }
        public decimal? Percent { get; set; }
        public decimal Amount { get; set; }
        public bool HasIssue { get; set; }

        public virtual CsFeeType FeeType { get; set; }
        public virtual SalesRemit Remit { get; set; }
        public virtual ICollection<RemitCmD> RemitCmDs { get; set; }
    }
}
