using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObInv
    {
        public int InvRptId { get; set; }
        public int RptId { get; set; }
        public decimal? ProcurableProductOutOfStockRate { get; set; }
        public int? OpenPurchaseOrderUnits { get; set; }
        public decimal? ReceiveFillRate { get; set; }
        public decimal? AverageVendorLeadTimeDays { get; set; }
        public decimal? SellThroughRate { get; set; }
        public int? UnfilledCustomerOrderedUnits { get; set; }
        public decimal? VendorConfirmationRate { get; set; }
        public decimal? NetReceivedInventoryCost { get; set; }
        public int? NetReceivedInventoryUnits { get; set; }
        public decimal? SellableOnHandInventoryCost { get; set; }
        public int? SellableOnHandInventoryUnits { get; set; }
        public decimal? UnsellableOnHandInventoryCost { get; set; }
        public int? UnsellableOnHandInventoryUnits { get; set; }
        public decimal? Aged90PlusDaysSellableInventoryCost { get; set; }
        public int? Aged90PlusDaysSellableInventoryUnits { get; set; }
        public decimal? UnhealthyInventoryCost { get; set; }
        public int? UnhealthyInventoryUnits { get; set; }
        public int IcrId { get; set; }
        public string Asin { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }

        public virtual MkIcr Icr { get; set; }
        public virtual AmzObRptT Rpt { get; set; }
    }
}
