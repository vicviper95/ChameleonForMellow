using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsCycleCount
    {
        public int CycleCountId { get; set; }
        public int LocationId { get; set; }
        public int BinId { get; set; }
        public int Qty { get; set; }
        public DateTime? DateTime { get; set; }
        public int ItemNoId { get; set; }
        public string Note { get; set; }
        public int? CounterId { get; set; }
        public int? Pallets { get; set; }
        public string PoNo { get; set; }

        public virtual WarehouseBin Bin { get; set; }
        public virtual Employee Counter { get; set; }
        public virtual KoItemno ItemNo { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
