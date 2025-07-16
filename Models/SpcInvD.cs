using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SpcInvD
    {
        public int SpcInvDId { get; set; }
        public int SpcInvTId { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public string PoNo { get; set; }
        public DateTime? ShipDate { get; set; }
        public string TrackingNo { get; set; }
        public string ShipFrName { get; set; }
        public string ShipFrCompany { get; set; }
        public string ShipFrCity { get; set; }
        public string ShipFrState { get; set; }
        public string ShipFrZip { get; set; }
        public string ShipToName { get; set; }
        public string ShipToCompany { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToState { get; set; }
        public string ShipToZip { get; set; }
        public int? ShipToCtryId { get; set; }
        public string Zone { get; set; }
        public decimal? Weight { get; set; }
        public int? ServiceId { get; set; }
        public int? PayTypeId { get; set; }
        public int? InvTypeId { get; set; }
        public decimal? NetCharge { get; set; }
        public int? SoTId { get; set; }
        public int? SoDId { get; set; }

        public virtual SpcInvType InvType { get; set; }
        public virtual SpcPayType PayType { get; set; }
        public virtual SpcService Service { get; set; }
        public virtual Country ShipToCtry { get; set; }
        public virtual SoD SoD { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual SpcInvT SpcInvT { get; set; }
    }
}
