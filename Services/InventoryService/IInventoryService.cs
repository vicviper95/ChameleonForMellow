using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chameleon.DTOs.Inventory;
using Chameleon.Models;
using Chameleon.Services.UtilityService;

namespace Chameleon.Services.InventoryService
{
  public interface IInventoryService
  {
    Task<List<GetInventoryItemDTO>> GetAllInventory(DateTime date);
    Task<List<GetMainslBancInvItemDTO>> GetMainslBancInv(int empId, DateTime date);
    Task<List<GetMainslBancInvItemDTO>> GetAdvInv(DateTime today);
    Task<GetMainslBancInvItemDTO> GetBOM(Bom setItem, int qtyLimit, List<GetMainslBancInvItemDTO> invItems, List<InvFeedsItem> invFeedsItemList, List<InvFeedsRemark> invFeedsRemarks);
    Task<List<GetMainslBancInvItemDTO>> GetAllMainslBancInv(DateTime today);
    Task<bool> UpdateInvFeedsItem(int empId, GetMainslBancInvItemDetailDTO itemDto);
    Task<List<GetMainslBancInvItemDTO>> GetUpdatedMainslBancInv(int empId, DateTime today);
    Task<List<GetMainslBancInvItemDTO>> GetUpdatedAllWarehousesInv(int empId, DateTime today, int sel);
    Task<List<GetMainslBancInvItemDTO>> LoadAllMainslBancInvFromDB(InvFeedsReport invFeedsReport);
    Task<List<GetMainslBancInvItemDTO>> CreateAllMainslBancInvItems(DateTime today);
    Task<List<GetInvSalesHistoryListItemDTO>> GetInvSalesHist(DateTime startDate, DateTime endDate);
    Task<List<GetInventoryFeedsItemDTO>> GetInvFeeds(DateTime startDate, DateTime endDate, DateTime today);
    Task<GetInventoryFeedsItemDTO> GetInvFeedsDetail(DateTime today, int itemNoId);
    Task<List<GetInventoryFeedsItemDTO>> GetInvAdvFeeds(DateTime startDate, DateTime endDate, DateTime today);
    Task<List<GetInventoryFeedsItemDTO>> RevGetInvAdvFeeds(DateTime startDate, DateTime endDate, DateTime today);
    Task<List<GetInventoryFeedsItemDTO>> GetInvFeedsHistory(DateTime historyDate);
    Task<GetInventoryFeedsItemDTO> GetInvFeedItemDetail(InvFeedsReportItem invFeedsReportItem);
    Task<bool> UpdateInvFeedItemDetail(int empId, GetInventoryFeedsItemDTO invFeedsItemDTO);
    Task<List<InvRealTime>> GetRealTimeInventory(DateTime date);
    Task<DateTime> GetLatestDateTimeOfInvRealTimeTable(DateTime date);
    Task<GetInventoryItemDTO> GetInventoryItem(int? id);
    Task<GetMainslBancInvItemDetailDTO> GetMainslBANCInventoryItem(long id);
    Task<List<GetAvailableInventoryNotesDTO>> GetAllAvailableInventoryNotesRules(int noteCategory);
    Task<List<GetInventoryFeedMarketRule>> GetAvailableInvFeedRules();
    Task<GetAvailableInventoryNotesDTO> GetAvailableInventoryNotesRules(int id);

    // For Inventory feeds history or export
    Task<List<AmazonFeedDTO>> GetInvFeedsAmazon(DateTime historyDate);
    Task<List<AmazonFeedDTO>> GetInvFeedsAmazon(int locId, DateTime historyDate);
    Task<List<WayfairFeedDTO>> GetInvFeedsWayfair(DateTime historyDate);
    Task<List<WalmartFeedDTO>> GetInvFeedsWalmart(int locId, DateTime historyDate);
    Task<List<OverstockFeedDTO>> GetInvFeedsOverstock(int locId, DateTime historyDate);
    Task<List<eBayMIPFeedDTO>> GetInvFeedseBay(DateTime historyDate);
    Task<List<HomeDepotFeedDTO>> GetHomeDepotInvFeeds(DateTime historyDate);
    Task<List<TargetEDIFeedDTO>> GetTargetInvFeeds(DateTime historyDate);
    Task<List<TargetEDIPastFeedDTO>> GetTargetPastInvFeeds(DateTime historyDate);
    Task<List<HouzzFeedDTO>> GetInvFeedsHouzz(DateTime historyDate);
    Task<List<ShopifyFeedDTO>> GetInvFeedsShopify(int custId, DateTime historyDate);
    Task<List<eBayFeedDTO>> GetInvFeedsOthers(DateTime historyDate);

    Task<ServiceResponse<GetInventoryItemDTO>> UpdateInventoryItem(UpdateInventoryItemDTO updateInventoryItem);
    //Task<bool> SaveInventoryFeeds(long reportId, List<GetInventoryFeedsItemDTO> invFeedsItemList);
    Task<GetInventoryFeedMarketRule> GetInventoryFeedingRule(int ruleId);
    //Task<GetInventoryFeedMarketRule> SaveInventoryFeedingRule(GetInventoryFeedMarketRule getInventoryFeedMarketRule);
    GetInventoryFeedsItemDTO AutoCalcInvFeeds(GetInventoryFeedsItemDTO invFeedsItem, GetInvSalesHistoryListItemDTO saleHistItem, List<InvFeedsRule> invFeedsRules, List<InvFeedsRuleSku> invFeedsRulesSKUs);

    GetInventoryFeedsItemDTO AutoCalcInvFeedsForLowSalesHistory(GetInventoryFeedsItemDTO invFeedsItem, List<InvFeedsRule> invFeedsRules, List<InvFeedsRuleSku> invFeedsRulesSKUs);
    Task<bool> UpdateAmazonFeedsList(int empId, AmazonFeedsListImportDTO amazonFeedsList);
    Task<bool> UpdateBpmMellowFeedsList(int empId, BpmMellowFeedsListImportDTO bpmMellowFeedsList);
    //Task<bool> UpdateOverstockFeedsList(int empId, OverstockFeedsListImportDTO overstockFeedsList);
    Task<bool> UpdateMarketFeedsList(int empId, int customerId, List<MarketFeedsListItemImportDTO> marketFeedsListItemImportDTOs);
    Task<bool> UpdateWayfairFeedsList(int empId, WayfairFeedsListImportDTO wayfairFeedsListImportDTO);
    Task<List<InvFeedsRemarkSKUGroupDTO>> GetSKUFeedingStatusList();
    Task<List<InvFeedsMarketSKUStatusDTO>> GetInvFeedsSKUFeedingStatusList(int customerId, bool returnConflicted);
    Task<bool> UpdateCustomerSKUFeedingStatusList(int empId, InvFeedsStatusUpdatingListDTO invFeedsStatusUpdatingListDTO);
    Task<InvFeedsSKUStatusDTO> GetSKUFeedingStatus(int itemNoId);

    Task<InvFeedsGeneralSettingDTO> GetInvFeedsGeneralSetting();
    Task<bool> UpdateSKUFeedingStatus(InvFeedsSKUStatusDTO invFeedsSKUStatusDTO);
    Task<List<InvFeedsRemarkSKUGroupDTO>> GetRemarkGroupItems(int remarkCategoryId);

    Task<bool> UpdateInvFeedsRemarkGroupList(int empId, InvFeedsRemarkSKUGroupListDTO updatedList);
    Task<bool> UpdateInvFeedsSetting(int empId, InvFeedsGeneralSettingDTO invFeedsGeneralSettingDTO);
    Task<List<ComparedInvFeedsDTO>> CompareInvFeeds(InvFeedsFromUserDTO invFeedsFromUserDTO);
    Task<List<ComparedInvFeedsDTO>> CompareWayfairInvFeeds(InvFeedsWayfairFromUserDTO invFeedsFromUserDTO);
    Task<List<ComparedInvFeedsDTO>> CompareHomeDepotInvFeeds(InvFeedsHomeDepotFromUserDTO invFeedsFromUserDTO);
    Task<InvFeedsStockItemDetailDTO> GetInvFeedsSKUStockRule(long id);
    Task<bool> UpdateInvFeedsSKUStockRule(int empId, InvFeedsStockItemDetailDTO invFeedsStockItemDetailDTO);

    // Added
    Task<bool> FillAvgSO(DateTime refDate);
    Task<bool> FillItemAbcPM(DateTime refDate);
    Task<bool> CalculateItemABCPM();
    double calMarketRatioByParetoRule(int calMethod, int smallMarketsCnt, int marketId, InventoryConfig inventoryConfig, InvSalesParetoRuleListItemDTO invParetoListItem, GetInventoryFeedsItemDTO getInventoryFeedsItemDTO);
    Task<List<InvSalesParetoRuleListItemDTO>> GetInvFeedParetoRuleItems(bool isImport, DateTime today, InvFeedsReport invFeedReport, List<int> cgIds, List<int> bpmIds);
    Task<List<GetInventoryFeedsItemDTO>> GetNewInvFeeds(DateTime startDate, DateTime endDate, DateTime today);
    Task<InventoryFeedsImportResponseDTO> ReviseInventoryFeedsByUser(int empId, List<UserRevisedInvFeedsDTO> invFeedsByUserList);
    Task<InventoryFeedsImportResponseDTO> ReviseWarehouseQtyByUser(int empId, List<UserRevisedWarehouseQtyDTO> warehouseQtyByUserList);
    Task<bool> ResetAllTheRulesOnSKUs(int empId);

    Task<int> calculateStageBackOrderSUM(int locId, int leadTime, int itemNoId);

    Task<int> taskCalculateStageBackOrderSUM(int locId, int leadTime, int itemNoId, int result);
    Task<bool> UpsertInvFeedsTable(long invFeedsRepId, List<GetInventoryFeedsItemDTO> invFeedsItemList);
    Task<int> InvFeedsQtyToTargetEDI(int empId, DateTime today);
    List<GetInventoryFeedsItemDTO> DistributeLeftOverQty(int smallMarketsCnt, List<GetInventoryFeedsItemDTO> invFeedsItemList);
    Task<List<WayfairFeedDTO>> GetInvFeedsWayfairRev(DateTime date);
    Task<List<AmazonFeedDTO>> GetInvFeedsAmazonRev(int locId, DateTime historyDate);
    Task<List<OverstockFeedDTO>> GetInvFeedsOverstockRev(int locId, DateTime historyDate);
    Task<List<WalmartFeedDTO>> GetInvFeedsWalmartRev(int locId, DateTime historyDate);
    Task<SetSKUDetail> GetSetSKUDetail(int itemId);
    Task<List<LeftOverWarehouseQtyDTO>> GetLeftOverQty(DateTime today);
    Task<List<LeftOverWarehouseQtyDTO>> LoadLeftOverQtyFromAllWarehouses(InvFeedsReport invFeedsReport);
    Task<List<GetInventoryFeedsItemDTO>> FeedLeftOverQtyFromWarehouse(List<GetInventoryFeedsItemDTO> invFeedsItemList);

    Task<bool> UpdateInvFeedsLeftOverAtWarehousesList(int empId, LeftOverWarehouseQtyListDTO leftOverList);
    Task<List<InvFeedsAllStopFeedFrom>> GetAllStopWHsList();
    Task<GetInventoryFeedsItemDTO> InventoryFeedsCustomRulesParetoDataRule(int LocId, int smallMarketsCnt, InvSalesParetoRuleListItemDTO invParetoListItem, InventoryConfig inventoryConfig, List<InvFeedsRule> invFeedsRules, InvFeedsRuleSku invFeedsRuleSku, GetInventoryFeedsItemDTO getInventoryFeedsItemDTO);
    Task<GetInventoryFeedsItemDTO> InventoryFeedsNewItemLowSalesDataRule(int LocId, List<InvFeedsRule> invFeedsRules, InvFeedsRuleSku invFeedsRuleSku, GetInventoryFeedsItemDTO getInventoryFeedsItemDTO);
    Task<GetInventoryFeedsItemDTO> InventoryFeedsLowInventoryRule(int LocId, List<InvFeedsRule> invFeedsRules, GetInventoryFeedsItemDTO getInventoryFeedsItemDTO, InventoryConfig inventoryConfig);
    //Task<List<GetInventoryFeedsItemDTO>> UpdateFeedingQtyForSlaveSkus(InventoryConfig inventoryConfig, List<GetInventoryFeedsItemDTO> invFeedsItems);
    void UpdateInventoryTest();
    //Task<List<ShopifyFeedDTO>> GetInvFeedsShopifyRev(int custId, DateTime historyDate);
    //Task<List<eBayMIPFeedDTO>> GetInvFeedseBayRev(DateTime historyDate);

    Task<InvFeedsImportResponse> ProcessDailyZeroOutSkus(int empId, List<ZeroOutSKU> zeroOutSkus);
    Task<InvFeedsImportResponse> DailyFastMovingSKUs(int empId, List<ImportedFastMovingSKUDTO> fastMovingSKUs, IUtilityService _utilService);
    //Task<bool> SendEmail (int emailType, string titleOfEmail,string contentOfEmail);

    Task<List<GetInventoryFeedsItemDTO>> GetSlaveSkuMkIcrFeeding (int ratioOfSku, List<GetInventoryFeedsItemDTO> inventoryFeedsItemDTOs);

    Task<GetInventoryFeedsItemDTO> CheckWayfairCGStockRule (int minimumQty, GetInventoryFeedsItemDTO inventoryFeedsItemDTOs);
    Task<bool> SaveCurrentWarehousesStatus(long realTimeRepId, List<GetMainslBancInvItemDTO> inventoryItems);

    //GetFastMovingSkus
    Task<List<FastMovingSkuDTO>> GetFastMovingSkus (int empId, DateTime today, string fromClick);
    Task<InvFeedsImportResponse> AutoFastMovingNotification (int empId, IUtilityService _utilService);
    bool CheckSKURulePeriod (InvFeedsRuleSkumkt invFeedsRuleSkumkt);
    GetInventoryFeedsItemDTO CheckWFS (InventoryConfig inventoryConfig, List<TplInvRptD> wfsRepDetails, GetInventoryFeedsItemDTO getInventoryFeedsItemDTO);
  }
}
