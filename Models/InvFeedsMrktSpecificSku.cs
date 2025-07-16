using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsMrktSpecificSku
    {
        public long InvFeedsMrktSpecificSkuid { get; set; }
        public int? CustomerId { get; set; }
        public int? ItemNoId { get; set; }
        public bool? IsActivated { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? IcrId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual NsIcr Icr { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual Employee LastModifiedByNavigation { get; set; }
    }
}
