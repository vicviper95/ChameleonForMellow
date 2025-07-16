using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmtCarrierApi
    {
        public int CarrierId { get; set; }
        public int ShipViaId { get; set; }
        public int CarrierMethod { get; set; }
        public string CarrierName { get; set; }

        public virtual ShipVium ShipVia { get; set; }
    }
}
