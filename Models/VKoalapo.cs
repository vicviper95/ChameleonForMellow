using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VKoalapo
    {
        public string Ponumber { get; set; }
        public string Vendor { get; set; }
        public DateTime? PoEtd { get; set; }
        public int? PolineId { get; set; }
        public int? LocationId { get; set; }
        public int? ItemnoId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? QtyOrdered { get; set; }
        public int? QtyOutstand { get; set; }
        public int? ContainerId { get; set; }
        public int? QtyContainer { get; set; }
    }
}
