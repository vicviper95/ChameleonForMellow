using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TplBegInventory
    {
        public int InvHistoryId { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyOnHand { get; set; }
        public int? LocationDetailId { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
