using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RemitInv
    {
        public RemitInv()
        {
            RemitInvDs = new HashSet<RemitInvD>();
        }

        public int RemitInvId { get; set; }
        public int RemitId { get; set; }
        public string Market { get; set; }
        public string RefNo { get; set; }
        public string PoNo { get; set; }
        public int? SoTId { get; set; }
        public decimal Amount { get; set; }
        public bool HasIssue { get; set; }
        public string Note { get; set; }
        public int? InvTId { get; set; }

        public virtual InvT InvT { get; set; }
        public virtual SalesRemit Remit { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual ICollection<RemitInvD> RemitInvDs { get; set; }
    }
}
