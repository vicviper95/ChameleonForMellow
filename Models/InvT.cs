using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvT
    {
        public InvT()
        {
            CrdDs = new HashSet<CrdD>();
            EdiTs = new HashSet<EdiT>();
            InvDs = new HashSet<InvD>();
            RemitInvs = new HashSet<RemitInv>();
        }

        public int InvTId { get; set; }
        public int? NsIntId { get; set; }
        public string InvNo { get; set; }
        public DateTime InvDate { get; set; }
        public decimal InvTotal { get; set; }
        public decimal? InvPaid { get; set; }
        public DateTime? DueDate { get; set; }
        public int InvStatusId { get; set; }
        public string MemoMain { get; set; }
        public DateTime AddedDate { get; set; }
        public string PoNo { get; set; }
        public int? CustomerId { get; set; }
        public int? SoTId { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public string RemitNo { get; set; }
        public bool? IsCreateFailed { get; set; }
        public string Source { get; set; }
        public int? GlimpactTId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual GlimpactT GlimpactT { get; set; }
        public virtual InvStatus InvStatus { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual ICollection<CrdD> CrdDs { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<InvD> InvDs { get; set; }
        public virtual ICollection<RemitInv> RemitInvs { get; set; }
    }
}
