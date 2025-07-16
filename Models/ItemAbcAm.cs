using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemAbcAm
    {
        public int ItemAbcAmId { get; set; }
        public DateTime FcstDate { get; set; }
        public int ItemNoId { get; set; }
        public string Abc { get; set; }
        public string Xyz { get; set; }
        public string Lmh { get; set; }
        public long IsNew { get; set; }
        public decimal AvgQty { get; set; }
        public decimal? StdDev { get; set; }
        public decimal? TovrBpm { get; set; }
        public decimal? TovrCastle { get; set; }
        public decimal TotalSale { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
