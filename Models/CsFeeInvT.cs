using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CsFeeInvT
    {
        public CsFeeInvT()
        {
            CsFeeClaimTs = new HashSet<CsFeeClaimT>();
            CsFeeInvDs = new HashSet<CsFeeInvD>();
        }

        public int FeeInvTId { get; set; }
        public int MarketId { get; set; }
        public string FeeInvNo { get; set; }
        public DateTime FeeInvDate { get; set; }
        public int FeeTypeId { get; set; }
        public int TotalInvQty { get; set; }
        public decimal TotalInvNet { get; set; }
        public decimal TotalFeeNet { get; set; }

        public virtual CsFeeType FeeType { get; set; }
        public virtual Market Market { get; set; }
        public virtual ICollection<CsFeeClaimT> CsFeeClaimTs { get; set; }
        public virtual ICollection<CsFeeInvD> CsFeeInvDs { get; set; }
    }
}
