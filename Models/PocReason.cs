using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PocReason
    {
        public PocReason()
        {
            PoChanges = new HashSet<PoChange>();
        }

        public int ChgReasonId { get; set; }
        public string Reason { get; set; }

        public virtual ICollection<PoChange> PoChanges { get; set; }
    }
}
