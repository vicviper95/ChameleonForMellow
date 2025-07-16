using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RmaAction
    {
        public RmaAction()
        {
            Rmas = new HashSet<Rma>();
        }

        public int RmaActionId { get; set; }
        public string RmaAction1 { get; set; }

        public virtual ICollection<Rma> Rmas { get; set; }
    }
}
