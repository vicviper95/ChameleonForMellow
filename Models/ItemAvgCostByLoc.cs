using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemAvgCostByLoc
    {
        public int ItemAvgCostByLocId { get; set; }
        public int ItemNoId { get; set; }
        public int LocationId { get; set; }
        public decimal Cost { get; set; }
        public DateTime LastModTime { get; set; }
        public decimal QtyOnHand { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
