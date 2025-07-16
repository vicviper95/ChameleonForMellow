using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsOrderDetail
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public int ShipFromWhId { get; set; }
        public string CustSku { get; set; }
        public int ItemNoId { get; set; }
        public int QtyOrdered { get; set; }
        public int QtyCancelled { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? DiscAmt { get; set; }
        public decimal? VatAmt { get; set; }
        public decimal? FeeAmt { get; set; }
        public int ShipViaId { get; set; }
        public string DiscCode { get; set; }
        public int ApplyDbst { get; set; }
        public string Note { get; set; }
        public int? OrderStatusId { get; set; }
        public int? ShipFromHdId { get; set; }
        public decimal? ShipAmt { get; set; }
        public int? QtyCommitted { get; set; }
        public int? QtyShipped { get; set; }
        public int? NsOdLineId { get; set; }
        public string ItemCat1 { get; set; }
        public string ItemCat2 { get; set; }
        public string ItemCat3 { get; set; }
        public int? QtyBackOrdered { get; set; }
        public int? QtyInvoiced { get; set; }
        public DateTime? ExpShipDate { get; set; }
        public DateTime? ActShipDate { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual NsOrder Order { get; set; }
        public virtual KoLocation ShipFromWh { get; set; }
        public virtual ShipVium ShipVia { get; set; }
    }
}
