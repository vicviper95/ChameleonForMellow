using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CsFeeInvD
    {
        public CsFeeInvD()
        {
            CsFeeClaimDs = new HashSet<CsFeeClaimD>();
        }

        public int FeeInvDId { get; set; }
        public int FeeInvTId { get; set; }
        public string PoNo { get; set; }
        public int? InvDId { get; set; }
        public string CustAsin { get; set; }
        public int ItemNoId { get; set; }
        public DateTime DateRcvd { get; set; }
        public int CsInvQty { get; set; }
        public decimal CsInvNet { get; set; }
        public decimal CsFeeNet { get; set; }
        public string CustUpc { get; set; }

        public virtual CsFeeInvT FeeInvT { get; set; }
        public virtual InvD InvD { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual ICollection<CsFeeClaimD> CsFeeClaimDs { get; set; }
    }
}
