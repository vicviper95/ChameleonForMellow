using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObNetPpm
    {
        public int NetPpmId { get; set; }
        public int RptId { get; set; }
        public int IcrId { get; set; }
        public string Asin { get; set; }
        public decimal? NetPureProductMargin { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }

        public virtual MkIcr Icr { get; set; }
        public virtual AmzObRptT Rpt { get; set; }
    }
}
