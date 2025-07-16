using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RemitInvT
    {
        public RemitInvT()
        {
            RemitInvDs = new HashSet<RemitInvD>();
        }

        public int RemitInvTId { get; set; }
        public int? NsIntId { get; set; }
        public int RemitId { get; set; }
        public int? CustomerId { get; set; }
        public string InvNo { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public decimal? ActAmount { get; set; }
        public DateTime? Date { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SalesRemit Remit { get; set; }
        public virtual ICollection<RemitInvD> RemitInvDs { get; set; }
    }
}
