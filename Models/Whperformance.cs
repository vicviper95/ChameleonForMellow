using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Whperformance
    {
        public int WhperformanceId { get; set; }
        public int LocId { get; set; }
        public bool Is3Pl { get; set; }
        public DateTime? InvoiceMonth { get; set; }
        public int? InboundQty { get; set; }
        public decimal? InboundExpense { get; set; }
        public int? OutboundQty { get; set; }
        public decimal? OutboundExpense { get; set; }
        public int? StorageQty { get; set; }
        public decimal? StorageExpense { get; set; }
        public int? OtherQty { get; set; }
        public decimal? OtherExpense { get; set; }
        public decimal? Tax { get; set; }
        public decimal? OfcfreightExpense { get; set; }
        public decimal? TotalExpense { get; set; }
        public int? TotalProcessed { get; set; }
        public int? HcfullTime { get; set; }
        public int? HcpartTime { get; set; }
        public int? Hctemp { get; set; }
        public string LocationName { get; set; }
        public decimal? RentWarehouse { get; set; }
        public decimal? RentEquip { get; set; }
        public decimal? RentTrailer { get; set; }
        public decimal? PayrollFullTime { get; set; }
        public decimal? PayrollTemp { get; set; }
        public decimal? PayrollTax { get; set; }
        public decimal? Supply { get; set; }
        public decimal? Freight { get; set; }
        public decimal? Utility { get; set; }
        public double? TotalQtyPerExp { get; set; }
        public double? InboundQtyPerExp { get; set; }
        public double? OutboundQtyPerExp { get; set; }
        public double? StorageQtyPerExp { get; set; }
        public double? OtherQtyPerExp { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Is3Pltotal { get; set; }
    }
}
