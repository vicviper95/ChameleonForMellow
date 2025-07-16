using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsAdjustDetail
    {
        public int AdjustDetailId { get; set; }
        public int AdjustId { get; set; }
        public int? BinId { get; set; }
        public int ItemNoId { get; set; }
        public int Qty { get; set; }
        public string Note { get; set; }
        public int LocationId { get; set; }

        public virtual WmsAdjust Adjust { get; set; }
        public virtual WarehouseBin Bin { get; set; }
        public virtual KoItemno ItemNo { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
