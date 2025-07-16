using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VInventoryHistory
    {
        public DateTime Date { get; set; }
        public string Itemno { get; set; }
        public string Location { get; set; }
        public int? QtyOnHand { get; set; }
    }
}
