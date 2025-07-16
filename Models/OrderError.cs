using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class OrderError
    {
        public int OrderErrorId { get; set; }
        public int MarketPlaceId { get; set; }
        public string CustomerPonumber { get; set; }
        public string CustSku { get; set; }
        public int? ShipVia { get; set; }
        public string Zip { get; set; }
        public string Note { get; set; }
    }
}
