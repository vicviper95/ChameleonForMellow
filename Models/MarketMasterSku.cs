using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MarketMasterSku
    {
        public MarketMasterSku()
        {
            MarketMasterItems = new HashSet<MarketMasterItem>();
            WfadsReportDProducts = new HashSet<WfadsReportDProduct>();
        }

        public int MasterSkuId { get; set; }
        public string Sku { get; set; }
        public string Collection { get; set; }
        public DateTime StartDate { get; set; }
        public int MarketId { get; set; }

        public virtual Market Market { get; set; }
        public virtual ICollection<MarketMasterItem> MarketMasterItems { get; set; }
        public virtual ICollection<WfadsReportDProduct> WfadsReportDProducts { get; set; }
    }
}
