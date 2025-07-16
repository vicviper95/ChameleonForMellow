using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObSalesManuFacturing
    {
        public int SalesId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal? OrdRevenue { get; set; }
        public int? OrdUnits { get; set; }
        public decimal? ShipedRevenue { get; set; }
        public decimal? ShippedCogs { get; set; }
        public int? ShippedUnits { get; set; }
        public decimal? RepOos { get; set; }
        public int? CustomerReturns { get; set; }
        public string Asin { get; set; }
        public string ItemName { get; set; }
        public int ItemNoId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
