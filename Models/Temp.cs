using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Temp
    {
        public long ForecastReportId { get; set; }
        public string ReportNo { get; set; }
        public DateTime CreatedImportDate { get; set; }
        public DateTime? FcTargetDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte? WeekOfYear { get; set; }
        public string Creator { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public long? Year { get; set; }
    }
}
