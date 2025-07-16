using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ForecastReport
    {
        public ForecastReport()
        {
            ForecastRepItems = new HashSet<ForecastRepItem>();
        }

        public long ForecastReportId { get; set; }
        public string ReportNo { get; set; }
        public DateTime CreatedImportDate { get; set; }
        public DateTime? FcTargetDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte? WeekOfYear { get; set; }
        public short? Year { get; set; }
        public string Creator { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string LastModifier { get; set; }
        public int? LastModifierId { get; set; }
        public bool? IsInbound { get; set; }

        public virtual ICollection<ForecastRepItem> ForecastRepItems { get; set; }
    }
}
