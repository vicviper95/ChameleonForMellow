using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ConsolidationInventoryT
    {
        public ConsolidationInventoryT()
        {
            ConsolidationInventoryDs = new HashSet<ConsolidationInventoryD>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual ICollection<ConsolidationInventoryD> ConsolidationInventoryDs { get; set; }
    }
}
