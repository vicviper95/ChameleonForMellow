using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfadsReportDProduct
    {
        public WfadsReportDProduct()
        {
            WfadsReportDs = new HashSet<WfadsReportD>();
        }

        public int ProductId { get; set; }
        public int MasterSkuId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual MarketMasterSku MasterSku { get; set; }
        public virtual ICollection<WfadsReportD> WfadsReportDs { get; set; }
    }
}
