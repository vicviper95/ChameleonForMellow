using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ConsolidationInventoryD
    {
        public int ConsolidationInventoryDId { get; set; }
        public int ConsolidationInventoryTId { get; set; }
        public int? LocationId { get; set; }
        public int? ItemNoId { get; set; }
        public int BeginQty { get; set; }
        public decimal BeginAmt { get; set; }
        public int InboundQty { get; set; }
        public decimal InboundAmt { get; set; }
        public int ProductQty { get; set; }
        public decimal ProductAmt { get; set; }
        public int GrotherQty { get; set; }
        public decimal GrotherAmt { get; set; }
        public int SalesQty { get; set; }
        public decimal SalesAmt { get; set; }
        public int GiotherQty { get; set; }
        public decimal GiotherAmt { get; set; }
        public int EndQty { get; set; }
        public decimal EndAmt { get; set; }
        public string ZinusSku { get; set; }

        public virtual ConsolidationInventoryT ConsolidationInventoryT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
