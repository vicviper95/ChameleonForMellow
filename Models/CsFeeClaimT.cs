using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CsFeeClaimT
    {
        public CsFeeClaimT()
        {
            CsClaimPayTs = new HashSet<CsClaimPayT>();
            CsFeeClaimDs = new HashSet<CsFeeClaimD>();
        }

        public int FeeClaimTId { get; set; }
        public int FeeInvTId { get; set; }
        public string ClaimNo { get; set; }
        public DateTime? ClaimDate { get; set; }
        public int TotalClaimQty { get; set; }
        public decimal TotalClaimNet { get; set; }
        public int? TotalPaidQty { get; set; }
        public decimal? TotalPaidNet { get; set; }
        public DateTime AddedDate { get; set; }
        public string Memo { get; set; }
        public DateTime LastModDate { get; set; }

        public virtual CsFeeInvT FeeInvT { get; set; }
        public virtual ICollection<CsClaimPayT> CsClaimPayTs { get; set; }
        public virtual ICollection<CsFeeClaimD> CsFeeClaimDs { get; set; }
    }
}
