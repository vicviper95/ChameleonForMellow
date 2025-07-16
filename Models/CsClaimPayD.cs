using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CsClaimPayD
    {
        public int ClaimPayDId { get; set; }
        public int ClaimPayTId { get; set; }
        public int? FeeClaimDId { get; set; }
        public int PaidQty { get; set; }
        public decimal PaidNet { get; set; }
        public string PoNo { get; set; }
        public string CustAsin { get; set; }

        public virtual CsClaimPayT ClaimPayT { get; set; }
        public virtual CsFeeClaimD FeeClaimD { get; set; }
    }
}
