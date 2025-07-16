using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoRcvT
    {
        public PoRcvT()
        {
            EdiTs = new HashSet<EdiT>();
            PoRcvDs = new HashSet<PoRcvD>();
        }

        public int RcvTId { get; set; }
        public int? NsIntId { get; set; }
        public string RcvNo { get; set; }
        public DateTime RcvDate { get; set; }
        public DateTime AddedDate { get; set; }
        public int PoTId { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public string PoNo { get; set; }
        public string ContNo { get; set; }
        public string TplRcvNo { get; set; }
        public string Source { get; set; }
        public string ExternalId { get; set; }
        public int? AccountId { get; set; }
        public int? GlimpactTId { get; set; }
        public int? ContainerId { get; set; }
        public int? OwnershipId { get; set; }
        public bool? IsValid { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual Container Container { get; set; }
        public virtual GlimpactT GlimpactT { get; set; }
        public virtual PoOwnershipT Ownership { get; set; }
        public virtual PoT PoT { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<PoRcvD> PoRcvDs { get; set; }
    }
}
