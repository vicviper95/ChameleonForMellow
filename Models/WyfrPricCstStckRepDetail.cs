using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WyfrPricCstStckRepDetail
    {
        public int RepDetailId { get; set; }
        public int WyfrPricCstStckRepId { get; set; }
        public string SkufromWayfair { get; set; }
        public string DisplaySku { get; set; }
        public string SupplierPartNo { get; set; }
        public string MfrPartNo { get; set; }
        public int? IcrId { get; set; }
        public int? ItemNoId { get; set; }
        public string ClassName { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string IsCg { get; set; }
        public string ShipClass { get; set; }
        public string ProductStatus { get; set; }
        public DateTime? SkulaunchMonth { get; set; }
        public string BrandType { get; set; }
        public string IsInExclusivityProgram { get; set; }
        public int? QtySoldLast90Days { get; set; }
        public decimal? Wsclast90Days { get; set; }
        public int? QtySoldLast12Months { get; set; }
        public decimal? Wsclast12Months { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? TaxAndDuties { get; set; }
        public decimal? RetailPriceNet { get; set; }
        public decimal? BaseCost { get; set; }
        public decimal? WholesaleCost { get; set; }
        public decimal? ShipOutboundCost { get; set; }
        public decimal? ShipOtherCost { get; set; }
        public decimal? IncidentAndReturnCost { get; set; }
        public decimal? Rebate { get; set; }
        public decimal? ProductAllowanceCost { get; set; }
        public decimal? OtherHandlingCost { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? B2cdiscount { get; set; }
        public decimal? Cgmarkdown { get; set; }
        public double? WscmrktCmpttvnssPercentile { get; set; }
        public double? ShpCstMrktCompttvnssPercentile { get; set; }
        public double? IncidentsAndReturnCstMrktCmpttvnssPercentile { get; set; }
        public DateTime? ReportWeekDate { get; set; }

        public virtual MkIcr Icr { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual WyfrPricCstStckReport WyfrPricCstStckRep { get; set; }
    }
}
