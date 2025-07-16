using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BolEntry
    {
        public BolEntry()
        {
            BillCreditTs = new HashSet<BillCreditT>();
            BolFeet = new HashSet<BolFoot>();
            PoBillTs = new HashSet<PoBillT>();
        }

        public int BolEntryId { get; set; }
        public string EntryNo { get; set; }
        public DateTime? EntryDate { get; set; }
        public decimal AmountEnteredValue { get; set; }
        public decimal AmountDuty { get; set; }
        public decimal AmountTax { get; set; }
        public decimal AmountOther { get; set; }
        public decimal AmountTotal { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual ICollection<BillCreditT> BillCreditTs { get; set; }
        public virtual ICollection<BolFoot> BolFeet { get; set; }
        public virtual ICollection<PoBillT> PoBillTs { get; set; }
    }
}
