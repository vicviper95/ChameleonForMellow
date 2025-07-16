using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VMarketFulfilledInvt
    {
        public DateTime Date { get; set; }
        public string MarketPlaceName { get; set; }
        public string Itemno { get; set; }
        public int InStockSupplyQty { get; set; }
        public int TotalSupplyQty { get; set; }
    }
}
