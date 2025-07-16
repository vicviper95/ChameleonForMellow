using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfadsReportType
    {
        public WfadsReportType()
        {
            WfadsReportTs = new HashSet<WfadsReportT>();
        }

        public int ReportTypeId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WfadsReportT> WfadsReportTs { get; set; }
    }
}
