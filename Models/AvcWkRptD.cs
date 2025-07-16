using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AvcWkRptD
    {
        public int AvcWkRptDId { get; set; }
        public int AvcWkRptTId { get; set; }
        public string CustAsin { get; set; }
        public int IcrId { get; set; }
        public decimal? OrderRev { get; set; }
        public int? OrderQty { get; set; }
        public int? QoHsableQty { get; set; }
        public decimal? QoHsableAmt { get; set; }
        public int? PoOpenQty { get; set; }
        public decimal? NetPpm { get; set; }
        public int? GlanceViews { get; set; }

        public virtual AvcWkRptT AvcWkRptT { get; set; }
        public virtual MkIcr Icr { get; set; }
    }
}
