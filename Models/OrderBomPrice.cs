using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class OrderBomPrice
    {
        public int OrderBomId { get; set; }
        public int OrderLineId { get; set; }
        public int ChiItemId { get; set; }
        public decimal ChiItemPrice { get; set; }

        public virtual OrderDetail OrderLine { get; set; }
    }
}
