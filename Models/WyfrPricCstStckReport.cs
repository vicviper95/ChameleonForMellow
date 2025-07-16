using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WyfrPricCstStckReport
    {
        public WyfrPricCstStckReport()
        {
            WyfrPricCstStckRepDetails = new HashSet<WyfrPricCstStckRepDetail>();
        }

        public int WyfrPricCstStckRepId { get; set; }
        public DateTime? ReportWeekDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string BrandCatalog { get; set; }

        public virtual ICollection<WyfrPricCstStckRepDetail> WyfrPricCstStckRepDetails { get; set; }
    }
}
