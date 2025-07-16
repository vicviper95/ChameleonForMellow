using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoAmzvendorRptSummary
    {
        public int SummaryId { get; set; }
        public string Kpis { get; set; }
        public decimal? Reported { get; set; }
        public decimal? PriorPeriod { get; set; }
        public decimal? LastYear { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
