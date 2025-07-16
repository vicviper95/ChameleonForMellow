using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ZinusSku
    {
        public int ZinusSkuId { get; set; }
        public string Customer { get; set; }
        public string ZinusSku1 { get; set; }
        public int ItemNoId { get; set; }
        public bool IsMasterSku { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
