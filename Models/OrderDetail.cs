using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            CancelDetails = new HashSet<CancelDetail>();
            OrderBomPrices = new HashSet<OrderBomPrice>();
            TrackingInfos = new HashSet<TrackingInfo>();
            WmsSoDetails = new HashSet<WmsSoDetail>();
        }

        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyOrdered { get; set; }
        public decimal PriceAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal MiscFeeAmt { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime? TimeShipped { get; set; }
        public string Note { get; set; }
        public string CustSku { get; set; }
        public DateTime? Time856Sent { get; set; }
        public DateTime? TimeShipRequested { get; set; }
        public DateTime? TimeShipArrived { get; set; }
        public DateTime? TimeRemitReceived { get; set; }
        public DateTime? TimeCarrierScan { get; set; }
        public DateTime? LastModDateTime { get; set; }
        public DateTime? AddedDateTime { get; set; }
        public int ItemOriginalId { get; set; }
        public int QtyBalance { get; set; }
        public int ShipFromWhouseId { get; set; }
        public string CustomerIolnumber { get; set; }
        public string MasterTrackNo { get; set; }
        public DateTime? Time855Sent { get; set; }
        public DateTime? TimeStaged { get; set; }
        public int? QtyAccepted { get; set; }
        public DateTime? TimeExpectToShip { get; set; }
        public DateTime? TimeCanceled { get; set; }
        public int QtyCancelled { get; set; }
        public int QtyShipped { get; set; }
        public DateTime? Time865Sent { get; set; }
        public DateTime? Time810Sent { get; set; }
        public DateTime? Time753Sent { get; set; }
        public DateTime? Time754Rcvd { get; set; }
        public DateTime? TimeAccept { get; set; }
        public DateTime? Time940Sent { get; set; }
        public int? ShipFromOriginalId { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual Order Order { get; set; }
        public virtual StatusOrder OrderStatus { get; set; }
        public virtual KoLocation ShipFromWhouse { get; set; }
        public virtual ICollection<CancelDetail> CancelDetails { get; set; }
        public virtual ICollection<OrderBomPrice> OrderBomPrices { get; set; }
        public virtual ICollection<TrackingInfo> TrackingInfos { get; set; }
        public virtual ICollection<WmsSoDetail> WmsSoDetails { get; set; }
    }
}
