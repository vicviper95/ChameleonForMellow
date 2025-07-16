using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvMktFeed
    {
        public int InvFeedId { get; set; }
        public DateTime TimeCreated { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int? QtyOnHand { get; set; }
        public int QtyAvail { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
