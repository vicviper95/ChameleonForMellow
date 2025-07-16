using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Upsinvoice
    {
        public int UpsinvoiceId { get; set; }
        public string AccountNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? AmountDue { get; set; }
        public string TrackingNumber { get; set; }
        public string CustomerSku { get; set; }
        public string CustomerPo { get; set; }
        public string KoOrderId { get; set; }
        public double? Weight { get; set; }
        public int? Zone { get; set; }
        public string ServiceLevel { get; set; }
        public DateTime? PickupDate { get; set; }
        public string ShipFromCompany { get; set; }
        public string ShipFromCity { get; set; }
        public string ShipToName { get; set; }
        public string ShipToStreet { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToState { get; set; }
        public string ShipToZipCode { get; set; }
        public decimal? BilledCharge { get; set; }
        public decimal? IncentiveCredit { get; set; }
        public string InvoiceSection { get; set; }
        public DateTime? InvoiceDueDate { get; set; }
        public int? ServiceTypeId { get; set; }
        public string Channel { get; set; }
        public bool IsUnknown { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public int? SoDId { get; set; }

        public virtual SoD SoD { get; set; }
    }
}
