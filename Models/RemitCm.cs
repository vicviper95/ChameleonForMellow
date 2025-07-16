using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RemitCm
    {
        public RemitCm()
        {
            RemitCmDs = new HashSet<RemitCmD>();
        }

        public int RemitCmId { get; set; }
        public int RemitId { get; set; }
        public string RefNo { get; set; }
        public string PoNo { get; set; }
        public int? SoTId { get; set; }
        public decimal Amount { get; set; }
        public string Market { get; set; }
        public bool HasIssue { get; set; }
        public string Note { get; set; }

        public virtual SalesRemit Remit { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual ICollection<RemitCmD> RemitCmDs { get; set; }
    }
}
