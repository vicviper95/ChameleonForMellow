using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PhysCountMsl
    {
        public PhysCountMsl()
        {
            InvCountEntries = new HashSet<InvCountEntry>();
        }

        public int PhysCountId { get; set; }
        public int BinNoId { get; set; }
        public int ItemNoId { get; set; }
        public int Qty1 { get; set; }
        public int? Qty2 { get; set; }
        public int QtyFinal { get; set; }
        public DateTime Time1 { get; set; }
        public DateTime? Time2 { get; set; }
        public string Note { get; set; }
        public int? QtyDiff { get; set; }

        public virtual MslBinNo BinNo { get; set; }
        public virtual KoItemno ItemNo { get; set; }
        public virtual ICollection<InvCountEntry> InvCountEntries { get; set; }
    }
}
