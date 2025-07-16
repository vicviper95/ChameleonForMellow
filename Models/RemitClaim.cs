using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RemitClaim
    {
        public RemitClaim()
        {
            RemitCmDs = new HashSet<RemitCmD>();
            RemitInvDs = new HashSet<RemitInvD>();
        }

        public int RemitClaimId { get; set; }
        public int RemitId { get; set; }
        public int? CmOriginId { get; set; }
        public bool HasIssue { get; set; }
        public string Note { get; set; }
        public string RefNo { get; set; }
        public decimal Amount { get; set; }
        public string DocNo { get; set; }

        public virtual CmOrigin CmOrigin { get; set; }
        public virtual SalesRemit Remit { get; set; }
        public virtual ICollection<RemitCmD> RemitCmDs { get; set; }
        public virtual ICollection<RemitInvD> RemitInvDs { get; set; }
    }
}
