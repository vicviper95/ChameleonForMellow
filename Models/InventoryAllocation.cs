using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InventoryAllocation
    {
        public int InvAllocId { get; set; }
        public DateTime DateTime { get; set; }
        public int LocationId { get; set; }
        public int? QAmD { get; set; }
        public int ItemNoId { get; set; }
        public int? QAmS { get; set; }
        public int? QOvs { get; set; }
        public int? QWal { get; set; }
        public int? QWaf { get; set; }
        public string Note { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
