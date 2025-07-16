namespace Chameleon.DTOs.Inventory
{
  public class LeftOverWarehouseQtyDTO
  {
    public bool isEdited { get; set; }
    public int itemNoId { get; set; }
    public string itemName { get; set; }
    public string itemStatus { get; set; }
    public int itemStatusId { get; set; }
    public string warehouse { get; set; }
    public int warehouseId { get; set; }
    public int qty { get; set; }
    public string assignedMarket { get; set; }
    public int assignedMarketId { get; set; }
  }
}
