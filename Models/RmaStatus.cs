using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RmaStatus
    {
        public RmaStatus()
        {
            Rmas = new HashSet<Rma>();
        }

        public int RmaStatusId { get; set; }
        public string RmaStatus1 { get; set; }

        public virtual ICollection<Rma> Rmas { get; set; }
    }
}
