using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoMarketPlace
    {
        public KoMarketPlace()
        {
            AdOrders = new HashSet<AdOrder>();
            CarrierAccounts = new HashSet<CarrierAccount>();
            CarrierMethodCodes = new HashSet<CarrierMethodCode>();
            CommittedSos = new HashSet<CommittedSo>();
            CompetingItems = new HashSet<CompetingItem>();
            CustomerInventoryAllocations = new HashSet<CustomerInventoryAllocation>();
            ItemListingItemnos = new HashSet<ItemListingItemno>();
            ItemSoldByComponents = new HashSet<ItemSoldByComponent>();
            ItemStdPrices = new HashSet<ItemStdPrice>();
            KoCompetingItems = new HashSet<KoCompetingItem>();
            KoPossibleSalesOrders = new HashSet<KoPossibleSalesOrder>();
            KoRetailPrcHistories = new HashSet<KoRetailPrcHistory>();
            KoRetailPriceHistories = new HashSet<KoRetailPriceHistory>();
            KoSalesTargets = new HashSet<KoSalesTarget>();
            NsOrders = new HashSet<NsOrder>();
            NsRemits = new HashSet<NsRemit>();
            Orders = new HashSet<Order>();
            RetailPriceHistories = new HashSet<RetailPriceHistory>();
            SalesEvents = new HashSet<SalesEvent>();
        }

        public int MarketPlaceId { get; set; }
        public string MarketPlaceName { get; set; }
        public byte IsSageCustomer { get; set; }
        public string Addr { get; set; }
        public int? ShipFromAddrId { get; set; }
        public int MasterMarketId { get; set; }
        public string CsvDelimiter { get; set; }
        public bool? CsvQuoteAllFields { get; set; }
        public string MarketPlaceNameZinus { get; set; }
        public string VendorId { get; set; }
        public string MarketType { get; set; }
        public string NscustomerName { get; set; }
        public int? NsIntId { get; set; }
        public string NsMarketPlace { get; set; }
        public string NsCategory { get; set; }
        public string NsOrderType { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }

        public virtual KoShipFromAddr ShipFromAddr { get; set; }
        public virtual ICollection<AdOrder> AdOrders { get; set; }
        public virtual ICollection<CarrierAccount> CarrierAccounts { get; set; }
        public virtual ICollection<CarrierMethodCode> CarrierMethodCodes { get; set; }
        public virtual ICollection<CommittedSo> CommittedSos { get; set; }
        public virtual ICollection<CompetingItem> CompetingItems { get; set; }
        public virtual ICollection<CustomerInventoryAllocation> CustomerInventoryAllocations { get; set; }
        public virtual ICollection<ItemListingItemno> ItemListingItemnos { get; set; }
        public virtual ICollection<ItemSoldByComponent> ItemSoldByComponents { get; set; }
        public virtual ICollection<ItemStdPrice> ItemStdPrices { get; set; }
        public virtual ICollection<KoCompetingItem> KoCompetingItems { get; set; }
        public virtual ICollection<KoPossibleSalesOrder> KoPossibleSalesOrders { get; set; }
        public virtual ICollection<KoRetailPrcHistory> KoRetailPrcHistories { get; set; }
        public virtual ICollection<KoRetailPriceHistory> KoRetailPriceHistories { get; set; }
        public virtual ICollection<KoSalesTarget> KoSalesTargets { get; set; }
        public virtual ICollection<NsOrder> NsOrders { get; set; }
        public virtual ICollection<NsRemit> NsRemits { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<RetailPriceHistory> RetailPriceHistories { get; set; }
        public virtual ICollection<SalesEvent> SalesEvents { get; set; }
    }
}
