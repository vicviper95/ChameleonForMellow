using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfadsTargetingType
    {
        public WfadsTargetingType()
        {
            WfadsReportTs = new HashSet<WfadsReportT>();
        }

        public int TargetingTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<WfadsReportT> WfadsReportTs { get; set; }
    }
}
