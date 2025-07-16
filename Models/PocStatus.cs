using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PocStatus
    {
        public PocStatus()
        {
            PoChanges = new HashSet<PoChange>();
        }

        public int PocStatusId { get; set; }
        public string Status { get; set; }
        public int? OrderIndex { get; set; }

        public virtual ICollection<PoChange> PoChanges { get; set; }
    }
}
