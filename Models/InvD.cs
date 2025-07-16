using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvD
    {
        public InvD()
        {
            CmDs = new HashSet<CmD>();
            CsFeeInvDs = new HashSet<CsFeeInvD>();
        }

        public int InvDId { get; set; }
        public int? NsIntId { get; set; }
        public int? SoDId { get; set; }
        public int InvTId { get; set; }
        public int? InvLineNo { get; set; }
        public int ItemNoId { get; set; }
        public int QtyInv { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public string MemoLine { get; set; }
        public DateTime? SoDate { get; set; }
        public DateTime? LastModTime { get; set; }
        public int? SodLineNo { get; set; }

        public virtual InvT InvT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual SoD SoD { get; set; }
        public virtual ICollection<CmD> CmDs { get; set; }
        public virtual ICollection<CsFeeInvD> CsFeeInvDs { get; set; }
    }
}
