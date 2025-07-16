using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemFobPc
    {
        public int ItemFobId { get; set; }
        public int ItemNoId { get; set; }
        public string Country { get; set; }
        public decimal? FobLast { get; set; }
        public decimal? FobAvg { get; set; }
        public decimal? FobMan { get; set; }
        public string FobSource { get; set; }
        public decimal? FobCost { get; set; }
        public DateTime LastModTime { get; set; }
        public int LastModEid { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
