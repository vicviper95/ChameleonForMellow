using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PrePo
    {
        public PrePo()
        {
            PoDs = new HashSet<PoD>();
            PrePohistories = new HashSet<PrePohistory>();
        }

        public long PrePoid { get; set; }
        public string InternalPono { get; set; }
        public int? RequestorId { get; set; }
        public string Requestor { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public string Pochannel { get; set; }
        public int? PochannelId { get; set; }
        public int? ItemNoId { get; set; }
        public string ItemName { get; set; }
        public int? RequestedQty { get; set; }
        public string RequestorsNote { get; set; }
        public DateTime? MustEtadate { get; set; }
        public bool? HasInitialApproval { get; set; }
        public DateTime? InitialApprovedDate { get; set; }
        public string InitialApprovedBy { get; set; }
        public int? InitialApprovedById { get; set; }
        public int? PrePostatusTypeId { get; set; }
        public int? MgmtAdjustedQty { get; set; }
        public string MgmtsNote { get; set; }
        public string MgmtApprovedBy { get; set; }
        public int? MgmtApprovedById { get; set; }
        public DateTime? MgmtApprovedDate { get; set; }
        public bool? HasMgmtApproved { get; set; }
        public bool? HasAcceptedByLogistics { get; set; }
        public DateTime? AcceptedByLogisticsDate { get; set; }
        public int? LogisticsConfirmedQty { get; set; }
        public string LogisticsChosenVendor { get; set; }
        public int? LogisticsChosenVendorId { get; set; }
        public DateTime? LogisticsEtdC { get; set; }
        public bool? HasLogisticsRegCompletion { get; set; }
        public string LogisticsPonoNote { get; set; }
        public DateTime? LogisticsCompletedDate { get; set; }
        public string LogisticsCompletedBy { get; set; }
        public int? LogisticsCompletedById { get; set; }
        public string LogisticsAcceptanceNote { get; set; }
        public string LogisticsAcceptedBy { get; set; }
        public int? LogisticsAcceptedById { get; set; }
        public bool? HasDeleted { get; set; }
        public int? DeletedById { get; set; }
        public int? ItemStatus { get; set; }
        public DateTime? MustEtadateUpdtdByLogistics { get; set; }
        public string ApprovalLevel { get; set; }

        public virtual ICollection<PoD> PoDs { get; set; }
        public virtual ICollection<PrePohistory> PrePohistories { get; set; }
    }
}
