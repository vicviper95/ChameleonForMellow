using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdOrder
    {
        public AdOrder()
        {
            AdOrderDetails = new HashSet<AdOrderDetail>();
        }

        public int OrderId { get; set; }
        public int VendorCodeId { get; set; }
        public string AmzPoNo { get; set; }
        public int ShipToAfcId { get; set; }
        public DateTime TimeOrdered { get; set; }
        public DateTime ShipWindowStart { get; set; }
        public DateTime ShipWindowEnd { get; set; }
        public int TotalBol { get; set; }
        public DateTime ExpShipDate { get; set; }
        public DateTime TimeAccepted { get; set; }
        public int MarketPalceId { get; set; }
        public int IsClosed { get; set; }
        public DateTime? AddedTime { get; set; }
        public int? AddedEmp { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? ModifiedEmp { get; set; }
        public int? NsIntId { get; set; }

        public virtual KoMarketPlace MarketPalce { get; set; }
        public virtual AdAfcid ShipToAfc { get; set; }
        public virtual AdVendorCode VendorCode { get; set; }
        public virtual ICollection<AdOrderDetail> AdOrderDetails { get; set; }
    }
}
