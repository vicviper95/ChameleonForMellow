using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzdirectPo
    {
        public int AmzdirectPoId { get; set; }
        public string Ponumber { get; set; }
        public string Vendor { get; set; }
        public string ShipToLocation { get; set; }
        public string Asin { get; set; }
        public string ExternalName { get; set; }
        public string Item { get; set; }
        public string Title { get; set; }
        public string Availability { get; set; }
        public string Backordered { get; set; }
        public string WindowType { get; set; }
        public DateTime? WindowStart { get; set; }
        public DateTime? WindowEnd { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public int? QuantityRequested { get; set; }
        public int? QuantityAccepted { get; set; }
        public int? QuantityReceived { get; set; }
        public int? QuantityOutstanding { get; set; }
        public double? UnitCost { get; set; }
        public double? TotalCost { get; set; }
        public int? ItemId { get; set; }
        public DateTime? AddedDateTime { get; set; }
        public int? AsinId { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
