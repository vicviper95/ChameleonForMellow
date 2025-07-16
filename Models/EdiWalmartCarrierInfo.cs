using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiWalmartCarrierInfo
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int? ShipViaId { get; set; }

        public virtual ShipVium ShipVia { get; set; }
    }
}
