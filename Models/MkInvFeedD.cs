using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MkInvFeedD
    {
        public int InvFeedDId { get; set; }
        public int InvFeedTId { get; set; }
        public int IcrId { get; set; }
        public int FeedQty { get; set; }

        public virtual MkIcr Icr { get; set; }
        public virtual MkInvFeedT InvFeedT { get; set; }
    }
}
