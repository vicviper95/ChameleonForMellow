using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoalaMasterInventory
    {
        public int BegInvId { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyBegin { get; set; }
        public int? QtyAllocDaily { get; set; }
        public int? QtyRcvd { get; set; }
        public int? QtyAllocAdir { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
