using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VTracking
    {
        public string TrackingNumber { get; set; }
        public DateTime? TimeShipped { get; set; }
        public string MarketPlaceName { get; set; }
        public string CustomerPonumber { get; set; }
        public string CustomerIolnumber { get; set; }
        public string Itemno { get; set; }
        public string CustSku { get; set; }
        public string ShippedItem { get; set; }
        public decimal PriceAmt { get; set; }
        public int QtyOrdered { get; set; }
        public string ShipFrom { get; set; }
        public string Note { get; set; }
        public int OrderId { get; set; }
    }
}
