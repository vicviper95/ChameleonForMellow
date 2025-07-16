using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstMarket
    {
        public FcstMarket()
        {
            FcstAvgSos = new HashSet<FcstAvgSo>();
            FcstWkHts = new HashSet<FcstWkHt>();
            FcstWkSos = new HashSet<FcstWkSo>();
            FcstWkTs = new HashSet<FcstWkT>();
            ItemAbcPms = new HashSet<ItemAbcPm>();
        }

        public short FcstMarketId { get; set; }
        public string MarketName { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual ICollection<FcstAvgSo> FcstAvgSos { get; set; }
        public virtual ICollection<FcstWkHt> FcstWkHts { get; set; }
        public virtual ICollection<FcstWkSo> FcstWkSos { get; set; }
        public virtual ICollection<FcstWkT> FcstWkTs { get; set; }
        public virtual ICollection<ItemAbcPm> ItemAbcPms { get; set; }
    }
}
