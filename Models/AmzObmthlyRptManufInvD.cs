using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObmthlyRptManufInvD
    {
        public int RptManufDInvId { get; set; }
        public int RptManufTId { get; set; }
        public string Asin { get; set; }
        public decimal? VendorConfirmationRate { get; set; }
        public decimal? NetReceived { get; set; }
        public int? NetReceivedUnits { get; set; }
        public int? OpenPurchaseOrderQuantity { get; set; }
        public decimal? ReceiveFillRate { get; set; }
        public decimal? OverallVendorLeadDays { get; set; }
        public decimal? Aged90DaysSellableInventory { get; set; }
        public int? Aged90DaysSellableUnits { get; set; }
        public decimal? SellableOnHandInventory { get; set; }
        public int? SellableOnHandUnits { get; set; }
        public decimal? UnsellableOnHandInventory { get; set; }
        public int? UnsellableOnHandUnits { get; set; }
        public decimal? SellThroughRate { get; set; }
        public decimal? UnhealthyInventory { get; set; }
        public int? UnhealthyUnits { get; set; }
        public int IcrId { get; set; }
        public decimal? ProcurableProductOos { get; set; }
        public int? UnfilledCustomerOrderedUnits { get; set; }

        public virtual MkIcr Icr { get; set; }
        public virtual AmzObrptManufT RptManufT { get; set; }
    }
}
