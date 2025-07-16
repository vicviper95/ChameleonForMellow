using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayfairDeduction
    {
        public int WayfairDeductionId { get; set; }
        public string Ponumber { get; set; }
        public string DeductionId { get; set; }
        public string DeductionLink { get; set; }
        public DateTime? SettlementDate { get; set; }
        public int? StatusId { get; set; }
        public string Resources { get; set; }
        public string DisputeReason { get; set; }
        public int? DeductionTypeId { get; set; }
        public string PartNoOrdered { get; set; }
        public int? PartNoOrderedMkIcrid { get; set; }
        public string ProblemReported { get; set; }
        public decimal? ProductCostAmnt { get; set; }
        public decimal? ShippingCostAmnt { get; set; }
        public decimal? VattaxCostAmnt { get; set; }
        public decimal? TotalDeductionAmnt { get; set; }

        public virtual WayfairDeductionType DeductionType { get; set; }
        public virtual MkIcr PartNoOrderedMkIcr { get; set; }
        public virtual WayfairDeductionStatus Status { get; set; }
    }
}
