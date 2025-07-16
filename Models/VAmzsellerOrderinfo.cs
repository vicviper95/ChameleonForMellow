using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VAmzsellerOrderinfo
    {
        public string CustomerPonumber { get; set; }
        public int? EndCustomerId { get; set; }
        public string FullName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public int? ItemnoId { get; set; }
        public int? QtyOrdered { get; set; }
        public double? PriceAmt { get; set; }
        public double? TaxAmt { get; set; }
        public double? MiscFeeAmt { get; set; }
        public byte? IsExpShipping { get; set; }
    }
}
