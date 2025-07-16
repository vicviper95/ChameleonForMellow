using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RemitService
    {
        public RemitService()
        {
            RemitCmDs = new HashSet<RemitCmD>();
            RemitInvDs = new HashSet<RemitInvD>();
        }

        public int RemitServiceId { get; set; }
        public int RemitId { get; set; }
        public string RefNo { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }

        public virtual SalesRemit Remit { get; set; }
        public virtual ICollection<RemitCmD> RemitCmDs { get; set; }
        public virtual ICollection<RemitInvD> RemitInvDs { get; set; }
    }
}
