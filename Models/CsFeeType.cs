using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CsFeeType
    {
        public CsFeeType()
        {
            CsFeeInvTs = new HashSet<CsFeeInvT>();
            RemitFees = new HashSet<RemitFee>();
        }

        public int FeeTypeId { get; set; }
        public int MarketId { get; set; }
        public string FeeName { get; set; }
        public string ShortName { get; set; }
        public decimal? FeePercent { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public virtual ICollection<CsFeeInvT> CsFeeInvTs { get; set; }
        public virtual ICollection<RemitFee> RemitFees { get; set; }
    }
}
