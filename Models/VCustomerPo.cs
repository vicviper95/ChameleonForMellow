using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VCustomerPo
    {
        public string Ponumber { get; set; }
        public byte? IsClosed { get; set; }
        public string VendorCode { get; set; }
        public DateTime ShipWindowEnd { get; set; }
        public DateTime ShipWindowStart { get; set; }
        public string Itemno { get; set; }
        public DateTime? ExpectedShipDate { get; set; }
        public byte? IsBackorder { get; set; }
        public int? QtySubmitted { get; set; }
        public int? QtyAccepted { get; set; }
        public int? QtyReceived { get; set; }
        public int? QtyOutstand { get; set; }
        public int? QtyTobeShipped { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? TotalCost { get; set; }
        public byte? IsCanceledButShipped { get; set; }
        public DateTime? LastModDateTime { get; set; }
    }
}
