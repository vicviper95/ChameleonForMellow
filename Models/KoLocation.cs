using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoLocation
    {
        public KoLocation()
        {
            BeginningInventories = new HashSet<BeginningInventory>();
            CarrierAccounts = new HashSet<CarrierAccount>();
            CycleCountMsls = new HashSet<CycleCountMsl>();
            CycleCountZhws = new HashSet<CycleCountZhw>();
            DemandForecasts = new HashSet<DemandForecast>();
            InvTxDailies = new HashSet<InvTxDaily>();
            InventoryAllocations = new HashSet<InventoryAllocation>();
            InventoryForecasts = new HashSet<InventoryForecast>();
            KoInventoryHistories = new HashSet<KoInventoryHistory>();
            KoalaMasterInventories = new HashSet<KoalaMasterInventory>();
            NsOrderDetails = new HashSet<NsOrderDetail>();
            OrderDetails = new HashSet<OrderDetail>();
            SkuSubstitudePlans = new HashSet<SkuSubstitudePlan>();
            TplBegInventories = new HashSet<TplBegInventory>();
            WarehouseBins = new HashSet<WarehouseBin>();
            WmsAdjustDetails = new HashSet<WmsAdjustDetail>();
            WmsCycleCountPlans = new HashSet<WmsCycleCountPlan>();
            WmsCycleCounts = new HashSet<WmsCycleCount>();
            WmsInventoryQoHs = new HashSet<WmsInventoryQoH>();
            WmsTransferFromLocations = new HashSet<WmsTransfer>();
            WmsTransferToLocations = new HashSet<WmsTransfer>();
        }

        public int LocationId { get; set; }
        public string Location { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string LocIdAmazon { get; set; }
        public string LocIdOverstock { get; set; }
        public string LocIdWayfair { get; set; }
        public string LocNameWayfair { get; set; }
        public string LocNameCastle { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? AddedTime { get; set; }
        public string LocIdWalmartDsv { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BeginningInventory> BeginningInventories { get; set; }
        public virtual ICollection<CarrierAccount> CarrierAccounts { get; set; }
        public virtual ICollection<CycleCountMsl> CycleCountMsls { get; set; }
        public virtual ICollection<CycleCountZhw> CycleCountZhws { get; set; }
        public virtual ICollection<DemandForecast> DemandForecasts { get; set; }
        public virtual ICollection<InvTxDaily> InvTxDailies { get; set; }
        public virtual ICollection<InventoryAllocation> InventoryAllocations { get; set; }
        public virtual ICollection<InventoryForecast> InventoryForecasts { get; set; }
        public virtual ICollection<KoInventoryHistory> KoInventoryHistories { get; set; }
        public virtual ICollection<KoalaMasterInventory> KoalaMasterInventories { get; set; }
        public virtual ICollection<NsOrderDetail> NsOrderDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<SkuSubstitudePlan> SkuSubstitudePlans { get; set; }
        public virtual ICollection<TplBegInventory> TplBegInventories { get; set; }
        public virtual ICollection<WarehouseBin> WarehouseBins { get; set; }
        public virtual ICollection<WmsAdjustDetail> WmsAdjustDetails { get; set; }
        public virtual ICollection<WmsCycleCountPlan> WmsCycleCountPlans { get; set; }
        public virtual ICollection<WmsCycleCount> WmsCycleCounts { get; set; }
        public virtual ICollection<WmsInventoryQoH> WmsInventoryQoHs { get; set; }
        public virtual ICollection<WmsTransfer> WmsTransferFromLocations { get; set; }
        public virtual ICollection<WmsTransfer> WmsTransferToLocations { get; set; }
    }
}
