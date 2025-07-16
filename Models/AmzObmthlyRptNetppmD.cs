using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObmthlyRptNetppmD
    {
        public int RptDNetPpmId { get; set; }
        public decimal? NetPpm { get; set; }
        public decimal? PriorNetPpm { get; set; }
        public decimal? YoYNetPpm { get; set; }
        public string Asin { get; set; }
        public int IcrId { get; set; }
        public int RptManufTId { get; set; }

        public virtual MkIcr Icr { get; set; }
        public virtual AmzObrptManufT RptManufT { get; set; }
    }
}
