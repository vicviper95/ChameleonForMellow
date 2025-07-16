using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvTxDaily
    {
        public int InvTxId { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyPoRcvd { get; set; }
        public int QtyShipped { get; set; }
        public int QtyTransfer { get; set; }
        public int QtyReturned { get; set; }
        public int QtyAdjust { get; set; }
        public int QtyAllocated { get; set; }
        public int QtyBegin { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
