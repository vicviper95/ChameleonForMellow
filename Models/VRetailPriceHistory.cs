using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VRetailPriceHistory
    {
        public DateTime Date { get; set; }
        public string Itemno { get; set; }
        public string SellerName { get; set; }
        public string MarketPlaceName { get; set; }
        public double? Price { get; set; }
    }
}
