using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfadsReportT
    {
        public WfadsReportT()
        {
            WfadsReportDs = new HashSet<WfadsReportD>();
        }

        public int ReportTId { get; set; }
        public int ProgramTypeId { get; set; }
        public int ReportTypeId { get; set; }
        public int PeriodTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public int? TargetingTypeId { get; set; }
        public bool IsActive { get; set; }
        public decimal? DailyCap { get; set; }
        public decimal? LifetimeBudget { get; set; }
        public DateTime CampaignStartDate { get; set; }
        public DateTime? CampaignEndDate { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual WfadsDatePeriodType PeriodType { get; set; }
        public virtual WfadsProgramType ProgramType { get; set; }
        public virtual WfadsReportType ReportType { get; set; }
        public virtual WfadsTargetingType TargetingType { get; set; }
        public virtual ICollection<WfadsReportD> WfadsReportDs { get; set; }
    }
}
