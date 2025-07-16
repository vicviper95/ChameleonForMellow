using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SalesRemit
    {
        public SalesRemit()
        {
            NsPayments = new HashSet<NsPayment>();
            RemitClaims = new HashSet<RemitClaim>();
            RemitCmTs = new HashSet<RemitCmT>();
            RemitCms = new HashSet<RemitCm>();
            RemitFees = new HashSet<RemitFee>();
            RemitInvTs = new HashSet<RemitInvT>();
            RemitInvs = new HashSet<RemitInv>();
            RemitServices = new HashSet<RemitService>();
        }

        public int RemitId { get; set; }
        public int MarketId { get; set; }
        public string RemitNo { get; set; }
        public DateTime RemitDate { get; set; }
        public decimal RemitTotal { get; set; }
        public bool IsImported { get; set; }
        public bool IsProcessed { get; set; }
        public string Note { get; set; }
        public DateTime AddedTime { get; set; }
        public int? AddedEmpId { get; set; }
        public DateTime LastModTime { get; set; }
        public int? LastModeEmpId { get; set; }

        public virtual Employee AddedEmp { get; set; }
        public virtual Employee LastModeEmp { get; set; }
        public virtual Market Market { get; set; }
        public virtual ICollection<NsPayment> NsPayments { get; set; }
        public virtual ICollection<RemitClaim> RemitClaims { get; set; }
        public virtual ICollection<RemitCmT> RemitCmTs { get; set; }
        public virtual ICollection<RemitCm> RemitCms { get; set; }
        public virtual ICollection<RemitFee> RemitFees { get; set; }
        public virtual ICollection<RemitInvT> RemitInvTs { get; set; }
        public virtual ICollection<RemitInv> RemitInvs { get; set; }
        public virtual ICollection<RemitService> RemitServices { get; set; }
    }
}
