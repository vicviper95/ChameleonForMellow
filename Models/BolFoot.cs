using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BolFoot
    {
        public BolFoot()
        {
            BillCreditTs = new HashSet<BillCreditT>();
            BolFeeDs = new HashSet<BolFeeD>();
            ContFeet = new HashSet<ContFoot>();
            PoBillTs = new HashSet<PoBillT>();
        }

        public int BolFeeTId { get; set; }
        public string Publisher { get; set; }
        public string InvNo { get; set; }
        public DateTime InvDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? Amount { get; set; }
        public string MasterBolNo { get; set; }
        public string HouseBolNo { get; set; }
        public int? BolEntryId { get; set; }
        public DateTime AddedTime { get; set; }
        public decimal? ServiceAmount { get; set; }
        public int? ToBolId { get; set; }
        public int? PoBolId { get; set; }
        public bool IsCreditNote { get; set; }

        public virtual BolEntry BolEntry { get; set; }
        public virtual PoBol PoBol { get; set; }
        public virtual ToBol ToBol { get; set; }
        public virtual ICollection<BillCreditT> BillCreditTs { get; set; }
        public virtual ICollection<BolFeeD> BolFeeDs { get; set; }
        public virtual ICollection<ContFoot> ContFeet { get; set; }
        public virtual ICollection<PoBillT> PoBillTs { get; set; }
    }
}
