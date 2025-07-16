using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SalesTax
    {
        public int SalesTaxId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public double TaxRate { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string ZipCode { get; set; }
    }
}
