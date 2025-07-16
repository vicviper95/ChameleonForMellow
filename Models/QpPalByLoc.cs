using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class QpPalByLoc
    {
        public int QpPalByLocId { get; set; }
        public int ItemNoId { get; set; }
        public int LocationId { get; set; }
        public int Qty { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
