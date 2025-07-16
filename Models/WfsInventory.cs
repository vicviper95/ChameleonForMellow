using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfsInventory
    {
        public int InvId { get; set; }
        public DateTime RptDate { get; set; }
        public string Gtin { get; set; }
        public string WmtItemId { get; set; }
        public string CustSku { get; set; }
        public string Status { get; set; }
        public decimal? DailSales { get; set; }
        public decimal? DailyUnitsSold { get; set; }
        public int? AvailableToSell { get; set; }
        public int? Reservations { get; set; }
        public int? InboundUnits { get; set; }
        public int? DaysOfSupply { get; set; }
        public DateTime? OosDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int IcrId { get; set; }
        public string MellowItemName { get; set; }

        public virtual MkIcr Icr { get; set; }
    }
}
