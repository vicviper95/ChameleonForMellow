using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoAmzvendorRptInvt
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int? AsinId { get; set; }
        public decimal? NetReceived { get; set; }
        public int? NetReceivedUnits { get; set; }
        public decimal? SellThroughRate { get; set; }
        public int? OpenPoqty { get; set; }
        public decimal? QtyOnHandValue { get; set; }
        public decimal? QtyOnHand30dAvg { get; set; }
        public int? QtyOnHand { get; set; }
        public decimal? UnsellableInventoryValue { get; set; }
        public decimal? UnsellableInventory30dAvg { get; set; }
        public int? UnsellableQtyOnHand { get; set; }
        public decimal? Over90daysSellableInventory { get; set; }
        public decimal? Over90daysInventory30dAvg { get; set; }
        public int? Over90daysSellableUnits { get; set; }
        public decimal? UnhealthyInventory { get; set; }
        public decimal? UnhealthyInventory30dAvg { get; set; }
        public int? UnhealthyUnits { get; set; }
        public string ReplenishmentCategory { get; set; }
        public string ItemNo { get; set; }
        public int InventoryId { get; set; }
        public string Asin { get; set; }
        public decimal Upc { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; }
        public string LocName { get; set; }
        public decimal? VendorConfirmationRate { get; set; }
        public decimal? ProcurableProductOos { get; set; }

        public virtual NsCustPn AsinNavigation { get; set; }
    }
}
