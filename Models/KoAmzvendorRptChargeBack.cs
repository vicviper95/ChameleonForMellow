using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoAmzvendorRptChargeBack
    {
        public int ChargeBackId { get; set; }
        public string IssueId { get; set; }
        public decimal FinancialCharge { get; set; }
        public int Quantity { get; set; }
        public string IssueType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DisputeBy { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public int? SubmittedQuantity { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string Asin { get; set; }
        public int? EarlyDays { get; set; }
        public DateTime? ShipWindowEnd { get; set; }
        public int? DaysLate { get; set; }
        public string OrderType { get; set; }
        public DateTime? ShipWindowStart { get; set; }
        public DateTime? RoutingRequestCreationDate { get; set; }
        public string SubtypeOfTheNoncompliance { get; set; }
        public int? ShipmentId { get; set; }
        public int? ConfirmedProductQuantity { get; set; }
        public string CarrierTrackingPronumber { get; set; }
    }
}
