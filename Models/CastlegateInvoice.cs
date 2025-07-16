using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CastlegateInvoice
    {
        public int CastlegateInvoiceId { get; set; }
        public string ChargeNumber { get; set; }
        public DateTime? ChargeDate { get; set; }
        public DateTime? EventDate { get; set; }
        public string Type { get; set; }
        public string OrderNumber { get; set; }
        public string RetailerName { get; set; }
        public string AdjustmentDescription { get; set; }
        public string Spo { get; set; }
        public string PartNumber { get; set; }
        public int? ProductUnits { get; set; }
        public double? Quantity { get; set; }
        public string Metric { get; set; }
        public double? Subtotal { get; set; }
        public string UsedMinimumCharge { get; set; }
        public string UsedMaximumCharge { get; set; }
        public string InvoiceNumber { get; set; }
        public double? UnitWholesaleCost { get; set; }
        public int? ExchangeRate { get; set; }
        public double? WarehouseWholesaleCost { get; set; }
        public double? TotalWholesaleCost { get; set; }
        public string ShipSpeed { get; set; }
        public string IsSelfInvoiced { get; set; }
        public string BatchNumber { get; set; }
        public string Warehouse { get; set; }
        public string AdminDescriptionNotes { get; set; }
    }
}
