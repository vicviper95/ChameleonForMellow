using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemAvgCost
    {
        public int ItemCostId { get; set; }
        public int ItemNoId { get; set; }
        public decimal AvgCost { get; set; }
        public int? QoH { get; set; }
        public int? QtyAvail { get; set; }
        public int? QtyOnOrd { get; set; }
        public DateTime LastModTime { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
