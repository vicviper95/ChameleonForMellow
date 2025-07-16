using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsInventoryQoH
    {
        public int BegInvId { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int? Qty { get; set; }
        public int? BinId { get; set; }
        public DateTime? LastModDateTime { get; set; }

        public virtual WarehouseBin Bin { get; set; }
        public virtual KoItemno ItemNo { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
