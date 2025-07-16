using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoItemno
    {
        public KoItemno()
        {
            AdOrderDetails = new HashSet<AdOrderDetail>();
            AdtemOnPallets = new HashSet<AdtemOnPallet>();
            BeginningInventories = new HashSet<BeginningInventory>();
            BillOfMaterialChildItems = new HashSet<BillOfMaterial>();
            BillOfMaterialParentItems = new HashSet<BillOfMaterial>();
            CommittedSos = new HashSet<CommittedSo>();
            CycleCountMsls = new HashSet<CycleCountMsl>();
            CycleCountZhws = new HashSet<CycleCountZhw>();
            DemandForecasts = new HashSet<DemandForecast>();
            InvTxDailies = new HashSet<InvTxDaily>();
            InventoryAllocations = new HashSet<InventoryAllocation>();
            InventoryForecasts = new HashSet<InventoryForecast>();
            ItemListingItemnos = new HashSet<ItemListingItemno>();
            ItemSoldByComponents = new HashSet<ItemSoldByComponent>();
            KoAmzvendorRpts = new HashSet<KoAmzvendorRpt>();
            KoCompetingItems = new HashSet<KoCompetingItem>();
            KoInventoryHistories = new HashSet<KoInventoryHistory>();
            KoPossiblePos = new HashSet<KoPossiblePo>();
            KoPossibleSalesOrders = new HashSet<KoPossibleSalesOrder>();
            KoPredSales = new HashSet<KoPredSale>();
            KoRetailPriceHistories = new HashSet<KoRetailPriceHistory>();
            KoalaMasterInventories = new HashSet<KoalaMasterInventory>();
            NsInvDetails = new HashSet<NsInvDetail>();
            NsOrderDetails = new HashSet<NsOrderDetail>();
            OrderDetails = new HashSet<OrderDetail>();
            OsitemConversions = new HashSet<OsitemConversion>();
            PhysCountMsls = new HashSet<PhysCountMsl>();
            RmaDetailItemReplaceds = new HashSet<RmaDetail>();
            RmaDetailItemShippeds = new HashSet<RmaDetail>();
            SkuSubstitudePlanItemFroms = new HashSet<SkuSubstitudePlan>();
            SkuSubstitudePlanItemTos = new HashSet<SkuSubstitudePlan>();
            TplBegInventories = new HashSet<TplBegInventory>();
            TrackingInfos = new HashSet<TrackingInfo>();
            WmsAdjustDetails = new HashSet<WmsAdjustDetail>();
            WmsCycleCountPlans = new HashSet<WmsCycleCountPlan>();
            WmsCycleCounts = new HashSet<WmsCycleCount>();
            WmsInventoryQoHs = new HashSet<WmsInventoryQoH>();
            WmsTransferDetails = new HashSet<WmsTransferDetail>();
            WyfItemConversions = new HashSet<WyfItemConversion>();
        }

        public int ItemNoId { get; set; }
        public string ItemNo { get; set; }
        public byte IsKitting { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double? Thickness { get; set; }
        public byte Obsolete { get; set; }
        public double? CartonLength { get; set; }
        public double? CartonWidth { get; set; }
        public double? CartonHeight { get; set; }
        public double? CartonWeight { get; set; }
        public double? ProductLength { get; set; }
        public double? ProductWidth { get; set; }
        public double? ProductHeight { get; set; }
        public double? ProductWeight { get; set; }
        public int? QtyPerPallet { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? AddedTime { get; set; }
        public string CategoryZinus { get; set; }
        public string CatSub1 { get; set; }
        public string CatSub2 { get; set; }
        public byte? IsNew { get; set; }
        public int? MrcQty { get; set; }
        public int? SortOrder { get; set; }
        public int? VendorId { get; set; }
        public string CategoryAd { get; set; }
        public int? NsIntId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Htscode { get; set; }
        public int? PalletTypeId { get; set; }
        public string MasterSku { get; set; }
        public int? Cat1Id { get; set; }
        public int? Cat2Id { get; set; }
        public int? Cat3Id { get; set; }
        public string CatSage { get; set; }
        public int? CatZinusId { get; set; }
        public string BpmUpc { get; set; }
        public int? ItemTypeId { get; set; }

        public virtual Category1 Cat1 { get; set; }
        public virtual Category2 Cat2 { get; set; }
        public virtual Category3 Cat3 { get; set; }
        public virtual CategoryZinu CatZinus { get; set; }
        public virtual PalletType PalletType { get; set; }
        public virtual KoAmzproduct KoAmzproduct { get; set; }
        public virtual KoWklySalesAvg KoWklySalesAvg { get; set; }
        public virtual KoWmtproduct KoWmtproduct { get; set; }
        public virtual ICollection<AdOrderDetail> AdOrderDetails { get; set; }
        public virtual ICollection<AdtemOnPallet> AdtemOnPallets { get; set; }
        public virtual ICollection<BeginningInventory> BeginningInventories { get; set; }
        public virtual ICollection<BillOfMaterial> BillOfMaterialChildItems { get; set; }
        public virtual ICollection<BillOfMaterial> BillOfMaterialParentItems { get; set; }
        public virtual ICollection<CommittedSo> CommittedSos { get; set; }
        public virtual ICollection<CycleCountMsl> CycleCountMsls { get; set; }
        public virtual ICollection<CycleCountZhw> CycleCountZhws { get; set; }
        public virtual ICollection<DemandForecast> DemandForecasts { get; set; }
        public virtual ICollection<InvTxDaily> InvTxDailies { get; set; }
        public virtual ICollection<InventoryAllocation> InventoryAllocations { get; set; }
        public virtual ICollection<InventoryForecast> InventoryForecasts { get; set; }
        public virtual ICollection<ItemListingItemno> ItemListingItemnos { get; set; }
        public virtual ICollection<ItemSoldByComponent> ItemSoldByComponents { get; set; }
        public virtual ICollection<KoAmzvendorRpt> KoAmzvendorRpts { get; set; }
        public virtual ICollection<KoCompetingItem> KoCompetingItems { get; set; }
        public virtual ICollection<KoInventoryHistory> KoInventoryHistories { get; set; }
        public virtual ICollection<KoPossiblePo> KoPossiblePos { get; set; }
        public virtual ICollection<KoPossibleSalesOrder> KoPossibleSalesOrders { get; set; }
        public virtual ICollection<KoPredSale> KoPredSales { get; set; }
        public virtual ICollection<KoRetailPriceHistory> KoRetailPriceHistories { get; set; }
        public virtual ICollection<KoalaMasterInventory> KoalaMasterInventories { get; set; }
        public virtual ICollection<NsInvDetail> NsInvDetails { get; set; }
        public virtual ICollection<NsOrderDetail> NsOrderDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OsitemConversion> OsitemConversions { get; set; }
        public virtual ICollection<PhysCountMsl> PhysCountMsls { get; set; }
        public virtual ICollection<RmaDetail> RmaDetailItemReplaceds { get; set; }
        public virtual ICollection<RmaDetail> RmaDetailItemShippeds { get; set; }
        public virtual ICollection<SkuSubstitudePlan> SkuSubstitudePlanItemFroms { get; set; }
        public virtual ICollection<SkuSubstitudePlan> SkuSubstitudePlanItemTos { get; set; }
        public virtual ICollection<TplBegInventory> TplBegInventories { get; set; }
        public virtual ICollection<TrackingInfo> TrackingInfos { get; set; }
        public virtual ICollection<WmsAdjustDetail> WmsAdjustDetails { get; set; }
        public virtual ICollection<WmsCycleCountPlan> WmsCycleCountPlans { get; set; }
        public virtual ICollection<WmsCycleCount> WmsCycleCounts { get; set; }
        public virtual ICollection<WmsInventoryQoH> WmsInventoryQoHs { get; set; }
        public virtual ICollection<WmsTransferDetail> WmsTransferDetails { get; set; }
        public virtual ICollection<WyfItemConversion> WyfItemConversions { get; set; }
    }
}
