using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InventoryAgingD
    {
        public int InventoryAgingDId { get; set; }
        public int InventoryAgingTId { get; set; }
        public int PoDId { get; set; }
        public int Qty { get; set; }

        public virtual InventoryAgingT InventoryAgingT { get; set; }
        public virtual PoD PoD { get; set; }
    }
}
