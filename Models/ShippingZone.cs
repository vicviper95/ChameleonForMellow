using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ShippingZone
    {
        public string DestZip { get; set; }
        public string OrigZip { get; set; }
        public int CarrierId { get; set; }
        public int Zone { get; set; }
        public int? ShipDays { get; set; }
        public int ShippingZoneId { get; set; }

        public virtual ShipCarrier Carrier { get; set; }
    }
}
