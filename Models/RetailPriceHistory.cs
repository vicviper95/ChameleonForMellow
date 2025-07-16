using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RetailPriceHistory
    {
        public int RpHistoryId { get; set; }
        public DateTime RptTime { get; set; }
        public int MarketPlaceId { get; set; }
        public int SellerId { get; set; }
        public int ItemNoId { get; set; }
        public decimal? Price { get; set; }
        public bool? IsOos { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual KoMarketPlace MarketPlace { get; set; }
        public virtual KoSeller Seller { get; set; }
    }
}
