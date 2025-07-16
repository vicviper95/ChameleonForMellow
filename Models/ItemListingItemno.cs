using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemListingItemno
    {
        public ItemListingItemno()
        {
            CustomerInventoryAllocations = new HashSet<CustomerInventoryAllocation>();
            ItemStdPrices = new HashSet<ItemStdPrice>();
            SalesEventDetails = new HashSet<SalesEventDetail>();
        }

        public int ItemListingId { get; set; }
        public int MarketPlaceId { get; set; }
        public string SellerSku { get; set; }
        public string SellerUnqId { get; set; }
        public string SellerUrlId { get; set; }
        public string Upc { get; set; }
        public int ItemNoId { get; set; }
        public byte IsGettingPrice { get; set; }
        public byte IsGettingRank { get; set; }
        public DateTime? LastModDateTime { get; set; }
        public DateTime? AddedDateTime { get; set; }
        public byte? IsInvReport { get; set; }
        public decimal? PriceWdsv { get; set; }
        public decimal? PriceGroupon { get; set; }
        public DateTime? LaunchDate { get; set; }
        public byte? IsWfsleepBrand { get; set; }
        public byte? IsNsImport { get; set; }
        public byte? IsLisingActive { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual KoMarketPlace MarketPlace { get; set; }
        public virtual ICollection<CustomerInventoryAllocation> CustomerInventoryAllocations { get; set; }
        public virtual ICollection<ItemStdPrice> ItemStdPrices { get; set; }
        public virtual ICollection<SalesEventDetail> SalesEventDetails { get; set; }
    }
}
