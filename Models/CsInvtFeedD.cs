using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CsInvtFeedD
    {
        public int CsInvtFeedDId { get; set; }
        public int CsInvtFeedTId { get; set; }
        public int LocationId { get; set; }
        public int IcrId { get; set; }
        public int FeedQty { get; set; }
        public int? FinalQty { get; set; }

        public virtual CsInvtFeedT CsInvtFeedT { get; set; }
        public virtual MkIcr Icr { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
