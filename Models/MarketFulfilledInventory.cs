using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MarketFulfilledInventory
    {
        public DateTime Date { get; set; }
        public int MarketPlaceId { get; set; }
        public int ItemNoId { get; set; }
        public int InStockSupplyQty { get; set; }
        public int TotalSupplyQty { get; set; }
    }
}
