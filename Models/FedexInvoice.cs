using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FedexInvoice
    {
        public FedexInvoice()
        {
            FedexInvoiceDetails = new HashSet<FedexInvoiceDetail>();
        }

        public int FedexInvoiceId { get; set; }
        public string FedexTrackingId { get; set; }
        public string PoRef { get; set; }
        public string OrigCustRefItem { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceNum { get; set; }
        public decimal? TransChargeAmt { get; set; }
        public decimal? NetChargeAmt { get; set; }
        public double? ActualWeightAmt { get; set; }
        public double? RatedWeightAmt { get; set; }
        public double? DimLength { get; set; }
        public double? DimWidth { get; set; }
        public double? DimHeight { get; set; }
        public string FedexZone { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddr1 { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToState { get; set; }
        public string ShipToPostalCode { get; set; }
        public string ServiceType { get; set; }
        public string ShipFromName { get; set; }
        public string ShipFromAddr1 { get; set; }
        public string ShipFromCity { get; set; }
        public string ShipFromState { get; set; }
        public string ShipFromPostalCode { get; set; }
        public string GroundService { get; set; }
        public string MasterTrackingId { get; set; }
        public string Konumber { get; set; }
        public string AccountNumber { get; set; }
        public string Channel { get; set; }
        public bool IsUnknown { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public int? SoTId { get; set; }
        public decimal? MiscChargeAmt { get; set; }
        public decimal? DutyTaxAmt { get; set; }
        public decimal? DiscountAmt { get; set; }
        public double? OriginalWeight { get; set; }
        public bool? IsDimFlag { get; set; }
        public int? Quantity { get; set; }
        public double? RatedWeight { get; set; }
        public int? SoDId { get; set; }

        public virtual SoD SoD { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual ICollection<FedexInvoiceDetail> FedexInvoiceDetails { get; set; }
    }
}
