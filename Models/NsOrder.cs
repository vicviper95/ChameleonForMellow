using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsOrder
    {
        public NsOrder()
        {
            NsInvoices = new HashSet<NsInvoice>();
            NsOrderDetails = new HashSet<NsOrderDetail>();
        }

        public int OrderId { get; set; }
        public int MarketPlaceId { get; set; }
        public string PoNo { get; set; }
        public string SoNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string FullName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string IoNo { get; set; }
        public DateTime? ExpShipDate { get; set; }
        public DateTime? ShipWindowStart { get; set; }
        public DateTime? ShipWindowEnd { get; set; }
        public DateTime? LastModDate { get; set; }
        public int? NsIntId { get; set; }
        public int? ShipToAfcId { get; set; }

        public virtual KoMarketPlace MarketPlace { get; set; }
        public virtual AdAfcid ShipToAfc { get; set; }
        public virtual ICollection<NsInvoice> NsInvoices { get; set; }
        public virtual ICollection<NsOrderDetail> NsOrderDetails { get; set; }
    }
}
