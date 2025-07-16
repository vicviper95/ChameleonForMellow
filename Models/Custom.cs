using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Custom
    {
        public int CustomsId { get; set; }
        public string HtsCode { get; set; }
        public int CountryId { get; set; }
        public decimal Duty { get; set; }
        public decimal Gsp { get; set; }
        public decimal Tariff { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Memo { get; set; }

        public virtual Country Country { get; set; }
    }
}
