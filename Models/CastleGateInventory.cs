using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CastleGateInventory
    {
        public int CgInventoryId { get; set; }
        public string ItemName { get; set; }
        public int TotalAvailable { get; set; }
        public string Warehouse { get; set; }
        public DateTime DateEnd { get; set; }
        public string PartNumber { get; set; }
        public int? TotalOnHand { get; set; }
        public int? TotalUnavailable { get; set; }
        public int? TotalOnTransfer { get; set; }
        public int? QtyAllocated { get; set; }
        public int? TotalOnOrder { get; set; }
        public int? QtyReceived1y { get; set; }
        public int? QtyShipped30d { get; set; }
        public int? QtyReserved { get; set; }
        public int? QtyUnpickable { get; set; }
        public int? QtyOnHold { get; set; }
        public int? QtyUnprocessedCycleCount { get; set; }
        public int? QtyUnprocessedAdjustment { get; set; }
        public int? ItemId { get; set; }
    }
}
