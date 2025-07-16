using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RmaReason
    {
        public RmaReason()
        {
            RmaReasonDetails = new HashSet<RmaReasonDetail>();
            Rmas = new HashSet<Rma>();
        }

        public int RmaReasonId { get; set; }
        public string RmaReason1 { get; set; }

        public virtual ICollection<RmaReasonDetail> RmaReasonDetails { get; set; }
        public virtual ICollection<Rma> Rmas { get; set; }
    }
}
