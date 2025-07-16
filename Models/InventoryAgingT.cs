using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InventoryAgingT
    {
        public InventoryAgingT()
        {
            InventoryAgingDs = new HashSet<InventoryAgingD>();
        }

        public int InventoryAgingTId { get; set; }
        public DateTime Date { get; set; }
        public int ItemNoId { get; set; }
        public int QtyOnHand { get; set; }
        public int? LocationId { get; set; }
        public DateTime AddedTime { get; set; }
        public int LocationTypeId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual LocationType LocationType { get; set; }
        public virtual ICollection<InventoryAgingD> InventoryAgingDs { get; set; }
    }
}
