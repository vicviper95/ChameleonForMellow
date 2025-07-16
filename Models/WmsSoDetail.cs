using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsSoDetail
    {
        public int OrderLineZoneId { get; set; }
        public int OrderLineId { get; set; }
        public int BinId { get; set; }
        public int Qty { get; set; }
        public DateTime DateTime { get; set; }

        public virtual WarehouseBin Bin { get; set; }
        public virtual OrderDetail OrderLine { get; set; }
    }
}
