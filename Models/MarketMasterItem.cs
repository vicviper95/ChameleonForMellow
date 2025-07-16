using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MarketMasterItem
    {
        public int MarketMasterItemId { get; set; }
        public int MasterSkuId { get; set; }
        public int ItemNoId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual MarketMasterSku MasterSku { get; set; }
    }
}
