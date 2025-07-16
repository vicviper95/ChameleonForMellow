using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoSoT
    {
        public KoSoT()
        {
            KoSoDs = new HashSet<KoSoD>();
        }

        public int KoSoTId { get; set; }
        public int CustomerId { get; set; }
        public string PoNo { get; set; }
        public string IoNo { get; set; }
        public DateTime SoDate { get; set; }
        public DateTime? ShipWindowStart { get; set; }
        public DateTime? ShipWindowEnd { get; set; }
        public DateTime? ExpShipDate { get; set; }
        public string ShipToName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime AddedDate { get; set; }
        public string Memo { get; set; }
        public string ShipCode { get; set; }
        public string ShipSpeed { get; set; }
        public string Source { get; set; }
        public int? ShipToAfcId { get; set; }
        public DateTime? CustOrdTime { get; set; }
        public string VendorCode { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<KoSoD> KoSoDs { get; set; }
    }
}
