using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObSale
    {
        public int SalesRptId { get; set; }
        public int RptId { get; set; }
        public string Asin { get; set; }
        public int? CustomerReturns { get; set; }
        public decimal? OrderedRevenue { get; set; }
        public int? OrderedUnits { get; set; }
        public decimal? ShippedCogs { get; set; }
        public decimal? ShippedRevenue { get; set; }
        public int? ShippedUnits { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public int IcrId { get; set; }
        public bool? IsRealTime { get; set; }

        public virtual MkIcr Icr { get; set; }
        public virtual AmzObRptT Rpt { get; set; }
    }
}
