using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfadsKeyMatchType
    {
        public WfadsKeyMatchType()
        {
            WfadsReportDKeywords = new HashSet<WfadsReportDKeyword>();
        }

        public int MatchTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<WfadsReportDKeyword> WfadsReportDKeywords { get; set; }
    }
}
