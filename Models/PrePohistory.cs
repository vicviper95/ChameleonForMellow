using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PrePohistory
    {
        public long PrePohistoryId { get; set; }
        public long? PrePoid { get; set; }
        public string Pochannel { get; set; }
        public string ItemName { get; set; }
        public int? RequestedQty { get; set; }
        public string RequestorsNote { get; set; }
        public DateTime? MustEtadate { get; set; }
        public int? PrePostatusTypeId { get; set; }
        public int? MgmtAdjustedQty { get; set; }
        public string MgmtsNote { get; set; }
        public int? LogisticsConfirmedQty { get; set; }
        public string LogisticsChosenVendor { get; set; }
        public DateTime? LogisticsEtdC { get; set; }
        public string LogisticsPonoNote { get; set; }
        public int? RevNo { get; set; }
        public string LogisticsAcceptanceNote { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? MustEtadateUpdtdByLogistics { get; set; }
        public string ApprovalLevel { get; set; }

        public virtual PrePo PrePo { get; set; }
    }
}
