using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcsWkHdatum
    {
        public int FcsWkHdataId { get; set; }
        public int FcstWkHtId { get; set; }
        public DateTime MondayOfWk { get; set; }
        public int PoIncoming { get; set; }
        public int InventoryNw { get; set; }
        public int InventoryBpm { get; set; }
        public int SalesActual { get; set; }
        public int? SalesFcst { get; set; }

        public virtual FcstWkHt FcstWkHt { get; set; }
    }
}
