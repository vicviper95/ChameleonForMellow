using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CsClaimPayT
    {
        public CsClaimPayT()
        {
            CsClaimPayDs = new HashSet<CsClaimPayD>();
        }

        public int ClaimPayTId { get; set; }
        public int FeeClaimTId { get; set; }
        public string PaymentNo { get; set; }
        public DateTime? PaidDate { get; set; }
        public int TotalPaidQty { get; set; }
        public decimal TotalPaidNet { get; set; }
        public string Memo { get; set; }
        public DateTime LastModDate { get; set; }

        public virtual CsFeeClaimT FeeClaimT { get; set; }
        public virtual ICollection<CsClaimPayD> CsClaimPayDs { get; set; }
    }
}
