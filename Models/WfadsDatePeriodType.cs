using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfadsDatePeriodType
    {
        public WfadsDatePeriodType()
        {
            WfadsReportTs = new HashSet<WfadsReportT>();
        }

        public int PeriodTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<WfadsReportT> WfadsReportTs { get; set; }
    }
}
