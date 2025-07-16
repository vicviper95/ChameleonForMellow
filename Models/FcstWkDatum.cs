using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstWkDatum
    {
        public int FcstWkDataId { get; set; }
        public int FcstWkDId { get; set; }
        public DateTime MondayOfWk { get; set; }
        public int InventoryNw { get; set; }
        public int? InventoryBpm { get; set; }
        public int FcstSaleQty { get; set; }
        public double FcstWoS { get; set; }
        public int? FcstCntsQty { get; set; }

        public virtual FcstWkD FcstWkD { get; set; }
    }
}
