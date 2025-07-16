using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoShipFromAddr
    {
        public KoShipFromAddr()
        {
            KoMarketPlaces = new HashSet<KoMarketPlace>();
        }

        public int ShipFromAddrId { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<KoMarketPlace> KoMarketPlaces { get; set; }
    }
}
