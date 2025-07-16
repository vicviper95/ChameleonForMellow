using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CarrierAccount
    {
        public int CarrierAcctId { get; set; }
        public int MarketPlaceId { get; set; }
        public int ShipFromLocationId { get; set; }
        public int CarrierId { get; set; }
        public string ShipAccNo { get; set; }
        public string BillAccNo { get; set; }

        public virtual ShipCarrier Carrier { get; set; }
        public virtual KoMarketPlace MarketPlace { get; set; }
        public virtual KoLocation ShipFromLocation { get; set; }
    }
}
