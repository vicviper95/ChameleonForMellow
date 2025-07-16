using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoSeller
    {
        public KoSeller()
        {
            CompetingItems = new HashSet<CompetingItem>();
            KoCompetingItems = new HashSet<KoCompetingItem>();
            KoRetailPrcHistories = new HashSet<KoRetailPrcHistory>();
            KoRetailPriceHistories = new HashSet<KoRetailPriceHistory>();
            RetailPriceHistories = new HashSet<RetailPriceHistory>();
        }

        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public virtual ICollection<CompetingItem> CompetingItems { get; set; }
        public virtual ICollection<KoCompetingItem> KoCompetingItems { get; set; }
        public virtual ICollection<KoRetailPrcHistory> KoRetailPrcHistories { get; set; }
        public virtual ICollection<KoRetailPriceHistory> KoRetailPriceHistories { get; set; }
        public virtual ICollection<RetailPriceHistory> RetailPriceHistories { get; set; }
    }
}
