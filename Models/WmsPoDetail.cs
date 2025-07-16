using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsPoDetail
    {
        public int PolineZoneId { get; set; }
        public int PolineId { get; set; }
        public int BinId { get; set; }
        public int Qty { get; set; }
        public DateTime DateTime { get; set; }

        public virtual WarehouseBin Bin { get; set; }
    }
}
