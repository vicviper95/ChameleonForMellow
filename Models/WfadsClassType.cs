using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfadsClassType
    {
        public WfadsClassType()
        {
            WfadsReportDs = new HashSet<WfadsReportD>();
        }

        public int ClassTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<WfadsReportD> WfadsReportDs { get; set; }
    }
}
