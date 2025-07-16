using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PocType
    {
        public PocType()
        {
            PoChanges = new HashSet<PoChange>();
        }

        public int PocTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<PoChange> PoChanges { get; set; }
    }
}
