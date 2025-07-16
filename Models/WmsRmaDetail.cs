using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsRmaDetail
    {
        public int RmaLineZoneId { get; set; }
        public int RmaLineId { get; set; }
        public int? BinId { get; set; }
        public int Qty { get; set; }
        public DateTime DateTime { get; set; }

        public virtual WarehouseBin Bin { get; set; }
        public virtual RmaDetail RmaLine { get; set; }
    }
}
