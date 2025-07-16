using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObmthlyRptManufSalesD
    {
        public int RptManufDSalesId { get; set; }
        public string Asin { get; set; }
        public decimal? OrderedRevenue { get; set; }
        public int? OrderedUnits { get; set; }
        public decimal? ShippedRevenue { get; set; }
        public decimal? ShippedCogs { get; set; }
        public int? ShippedUnits { get; set; }
        public int? CustomerReturns { get; set; }
        public int RptManufTId { get; set; }
        public int IcrId { get; set; }

        public virtual MkIcr Icr { get; set; }
        public virtual AmzObrptManufT RptManufT { get; set; }
    }
}
