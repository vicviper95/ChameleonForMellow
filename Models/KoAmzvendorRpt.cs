using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoAmzvendorRpt
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string ItemNo { get; set; }
        public int? UnitsShipped { get; set; }
        public int? QtyAmzful { get; set; }
        public int? QtyOpenPo { get; set; }
        public int? Amzobqty { get; set; }

        public virtual KoItemno ItemNoNavigation { get; set; }
    }
}
