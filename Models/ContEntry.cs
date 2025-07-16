using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ContEntry
    {
        public ContEntry()
        {
            BolFeet = new HashSet<BolFoot>();
            ContFeet = new HashSet<ContFoot>();
        }

        public int ContEntryId { get; set; }
        public string EntryNo { get; set; }
        public DateTime? EntryDate { get; set; }
        public string MasterBolno { get; set; }
        public decimal AmountEnteredValue { get; set; }
        public decimal AmountDuty { get; set; }
        public decimal AmountTax { get; set; }
        public decimal AmountOther { get; set; }
        public decimal AmountTotal { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual ICollection<BolFoot> BolFeet { get; set; }
        public virtual ICollection<ContFoot> ContFeet { get; set; }
    }
}
