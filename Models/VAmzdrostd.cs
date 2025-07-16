using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VAmzdrostd
    {
        public string Ponumber { get; set; }
        public string VendorCode { get; set; }
        public string Itemno { get; set; }
        public byte? IsKitting { get; set; }
        public DateTime? ExpectedShipDate { get; set; }
        public int? QtyAccepted { get; set; }
        public int? QtyTobeShipped { get; set; }
        public int? QtyReceived { get; set; }
        public int? QtyOutstand { get; set; }
        public byte? IsCanceledButShipped { get; set; }
        public decimal? InvQty { get; set; }
        public decimal? OstdQty { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? UnitCost { get; set; }
    }
}
