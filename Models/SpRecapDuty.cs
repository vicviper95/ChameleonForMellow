using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SpRecapDuty
    {
        public int SpRecapDutyId { get; set; }
        public string HtsCode { get; set; }
        public int CountryFrId { get; set; }
        public int CountryToId { get; set; }
        public decimal Duty { get; set; }
        public decimal Gsp { get; set; }
        public decimal Tariff { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Memo { get; set; }

        public virtual Country CountryFr { get; set; }
        public virtual Country CountryTo { get; set; }
    }
}
