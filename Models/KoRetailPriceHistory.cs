using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoRetailPriceHistory
    {
        public DateTime Date { get; set; }
        public int ItemNoId { get; set; }
        public int MarketPlaceId { get; set; }
        public double? Price { get; set; }
        public int SellerId { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual KoMarketPlace MarketPlace { get; set; }
        public virtual KoSeller Seller { get; set; }
    }
}
