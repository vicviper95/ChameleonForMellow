using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ShipVium
    {
        public ShipVium()
        {
            CarrierMethodCodes = new HashSet<CarrierMethodCode>();
            EdiCarriers = new HashSet<EdiCarrier>();
            EdiWalmartCarrierInfos = new HashSet<EdiWalmartCarrierInfo>();
            KoSoDs = new HashSet<KoSoD>();
            NsOrderDetails = new HashSet<NsOrderDetail>();
            Orders = new HashSet<Order>();
            SoDs = new HashSet<SoD>();
            WmtCarrierApis = new HashSet<WmtCarrierApi>();
        }

        public int ShipViaId { get; set; }
        public string ShipViaCode { get; set; }
        public string ShipViaName { get; set; }
        public int CarrierId { get; set; }
        public string ShippingType { get; set; }
        public string ShipViaShortName { get; set; }
        public byte? IsExpressShipping { get; set; }
        public string SvcAmazon { get; set; }
        public string WmtCarMethod { get; set; }
        public string NsShipItem { get; set; }
        public int NsIsSigReuired { get; set; }
        public int NsIsResidential { get; set; }
        public int? NsIntId { get; set; }

        public virtual ShipCarrier Carrier { get; set; }
        public virtual ICollection<CarrierMethodCode> CarrierMethodCodes { get; set; }
        public virtual ICollection<EdiCarrier> EdiCarriers { get; set; }
        public virtual ICollection<EdiWalmartCarrierInfo> EdiWalmartCarrierInfos { get; set; }
        public virtual ICollection<KoSoD> KoSoDs { get; set; }
        public virtual ICollection<NsOrderDetail> NsOrderDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SoD> SoDs { get; set; }
        public virtual ICollection<WmtCarrierApi> WmtCarrierApis { get; set; }
    }
}
