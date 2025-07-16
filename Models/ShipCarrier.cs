using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ShipCarrier
    {
        public ShipCarrier()
        {
            CarrierAccounts = new HashSet<CarrierAccount>();
            CustAddrs = new HashSet<CustAddr>();
            CustBillAddrs = new HashSet<CustBillAddr>();
            CustRetuAddrs = new HashSet<CustRetuAddr>();
            ShipAccts = new HashSet<ShipAcct>();
            ShipVia = new HashSet<ShipVium>();
            ShippingZones = new HashSet<ShippingZone>();
            SpcInvTs = new HashSet<SpcInvT>();
        }

        public int CarrierId { get; set; }
        public string CarrierName { get; set; }

        public virtual ICollection<CarrierAccount> CarrierAccounts { get; set; }
        public virtual ICollection<CustAddr> CustAddrs { get; set; }
        public virtual ICollection<CustBillAddr> CustBillAddrs { get; set; }
        public virtual ICollection<CustRetuAddr> CustRetuAddrs { get; set; }
        public virtual ICollection<ShipAcct> ShipAccts { get; set; }
        public virtual ICollection<ShipVium> ShipVia { get; set; }
        public virtual ICollection<ShippingZone> ShippingZones { get; set; }
        public virtual ICollection<SpcInvT> SpcInvTs { get; set; }
    }
}
