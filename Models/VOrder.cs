using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VOrder
    {
        public string MarketPlaceName { get; set; }
        public string CustomerPonumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerIonumber { get; set; }
        public DateTime? ShipWindowStart { get; set; }
        public DateTime? ShipWindowEnd { get; set; }
        public string ShipViaCode { get; set; }
        public string SageSoNo { get; set; }
        public string SageInvNo { get; set; }
        public DateTime? TimeKoCreated { get; set; }
        public string Itemno { get; set; }
        public string CustSku { get; set; }
        public string CustomerIolnumber { get; set; }
        public string Category { get; set; }
        public byte? IsKitting { get; set; }
        public int? QtyOrdered { get; set; }
        public decimal? PriceAmt { get; set; }
        public decimal? TaxAmt { get; set; }
        public decimal? MiscFeeAmt { get; set; }
        public string OrderStatus { get; set; }
        public string Note { get; set; }
        public DateTime? TimeshipRequested { get; set; }
        public DateTime? TimeAsnReported { get; set; }
        public DateTime? TimeAccepted { get; set; }
        public string Location { get; set; }
        public string MasterTrackNo { get; set; }
        public string FullName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? OdlastModDateTime { get; set; }
        public DateTime? OddlastModDateTime { get; set; }
    }
}
