using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdArntemp5d15870b
    {
        public int ArnId { get; set; }
        public long Arn { get; set; }
        public long? Asn { get; set; }
        public int AmzStatusId { get; set; }
        public string BolNo { get; set; }
        public int? BolId { get; set; }
        public string CarrierContact { get; set; }
        public string CarrierEmail { get; set; }
        public string CarrierMode { get; set; }
        public string CarrierPhone { get; set; }
        public string CarrierRefNo { get; set; }
        public int? CarrierId { get; set; }
        public DateTime? DateBolCreated { get; set; }
        public DateTime? DateDelivered { get; set; }
        public DateTime? DateEta { get; set; }
        public string InvoiceNo { get; set; }
        public bool IsAmzPicked { get; set; }
        public bool? IsBolChecked { get; set; }
        public int? IsBolSentToWh { get; set; }
        public int? IsClosed { get; set; }
        public bool? IsNeedsAsn { get; set; }
        public bool? IsRescheduled { get; set; }
        public int? IsStaged { get; set; }
        public int? IsVcInvoiced { get; set; }
        public DateTime LastModTime { get; set; }
        public string Note { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public string PoNo { get; set; }
        public string ProNo { get; set; }
        public int ShipFrWhId { get; set; }
        public string ShipLablePath { get; set; }
        public int ShipToAfcId { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? TimeAmzLabel { get; set; }
        public DateTime? TimeArnRcvd { get; set; }
        public DateTime TimeArqCreated { get; set; }
        public DateTime? TimeAsnSent { get; set; }
        public DateTime? TimeBolDoc { get; set; }
        public DateTime? TimeInvoiced { get; set; }
        public DateTime? TimePicked { get; set; }
        public DateTime? TimeShipReq { get; set; }
        public DateTime? TimeToPick { get; set; }
        public int TotalCarton { get; set; }
        public int TotalPallet { get; set; }
        public decimal? TotalVolCf { get; set; }
        public decimal? TotalWeightLb { get; set; }
    }
}
