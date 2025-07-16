using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemFobCc
    {
        public int ItemFobCcId { get; set; }
        public DateTime BegDateMo { get; set; }
        public int ItemNoId { get; set; }
        public string Country { get; set; }
        public decimal FobAvg4 { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
