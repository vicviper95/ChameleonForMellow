using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BeginningInventory
    {
        public int UnqId { get; set; }
        public int? DateKey { get; set; }
        public int ItemnoId { get; set; }
        public int LocationId { get; set; }
        public int QtyOnHand { get; set; }

        public virtual DimDate DateKeyNavigation { get; set; }
        public virtual KoItemno Itemno { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
