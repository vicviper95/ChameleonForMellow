using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoWklySalesAvg
    {
        public string ItemNo { get; set; }
        public double? WkAvg12 { get; set; }
        public double? WkAvg4 { get; set; }
        public double? PrevWk { get; set; }

        public virtual KoItemno ItemNoNavigation { get; set; }
    }
}
