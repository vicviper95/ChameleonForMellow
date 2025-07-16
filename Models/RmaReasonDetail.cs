using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RmaReasonDetail
    {
        public RmaReasonDetail()
        {
            Rmas = new HashSet<Rma>();
        }

        public int RmaReasonDetailId { get; set; }
        public string RmaReasonDetail1 { get; set; }
        public int RmaReasonId { get; set; }

        public virtual RmaReason RmaReason { get; set; }
        public virtual ICollection<Rma> Rmas { get; set; }
    }
}
