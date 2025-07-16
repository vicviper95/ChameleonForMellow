using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CarrierMethodCode
    {
        public int CarrierMethodId { get; set; }
        public string Description { get; set; }
        public int CarrierMethodId1 { get; set; }
        public int XmlCarrierMethodCode { get; set; }
        public int MarketPlaceId { get; set; }
        public int? ShipViaId { get; set; }

        public virtual KoMarketPlace MarketPlace { get; set; }
        public virtual ShipVium ShipVia { get; set; }
    }
}
