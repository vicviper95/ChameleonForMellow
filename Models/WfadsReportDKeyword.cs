using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfadsReportDKeyword
    {
        public WfadsReportDKeyword()
        {
            WfadsReportDs = new HashSet<WfadsReportD>();
        }

        public int KeywordId { get; set; }
        public decimal? MaxBid { get; set; }
        public string Value { get; set; }
        public int? MatchTypeId { get; set; }

        public virtual WfadsKeyMatchType MatchType { get; set; }
        public virtual ICollection<WfadsReportD> WfadsReportDs { get; set; }
    }
}
