using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvNsMend
    {
        public int InvMendId { get; set; }
        public DateTime DateRecord { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyOnHand { get; set; }
        public int? QtyAvail { get; set; }
        public DateTime LastModTime { get; set; }
        public decimal AmtOnHand { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
