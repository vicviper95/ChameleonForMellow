using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VCarrierAccount
    {
        public int CarrierAcctId { get; set; }
        public string MarketPlaceName { get; set; }
        public string ShipFromLocation { get; set; }
        public string CarrierName { get; set; }
        public string ShipAccNo { get; set; }
        public string BillAccNo { get; set; }
    }
}
