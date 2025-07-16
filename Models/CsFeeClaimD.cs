using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CsFeeClaimD
    {
        public CsFeeClaimD()
        {
            CsClaimPayDs = new HashSet<CsClaimPayD>();
        }

        public int FeeClaimDId { get; set; }
        public int FeeClaimTId { get; set; }
        public int FeeInvDId { get; set; }
        public string CustAsin { get; set; }
        public int ItemNoId { get; set; }
        public int AmzInvQty { get; set; }
        public decimal AmzInvNet { get; set; }
        public decimal AmzFeeNet { get; set; }
        public int ClaimQty { get; set; }
        public decimal ClaimNet { get; set; }
        public int? PaidQty { get; set; }
        public decimal? PaidNet { get; set; }
        public string PoNo { get; set; }
        public int BpmInvQty { get; set; }
        public decimal BpmInvNet { get; set; }
        public decimal BpmFeeNet { get; set; }

        public virtual CsFeeClaimT FeeClaimT { get; set; }
        public virtual CsFeeInvD FeeInvD { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual ICollection<CsClaimPayD> CsClaimPayDs { get; set; }
    }
}
