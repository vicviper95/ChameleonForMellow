using System;

namespace Chameleon.DTOs.Inventory
{
  public class UpdateInventoryItemDTO
  {
    public int InventoryItemId { get; set; }
    public int QtyOnHand { get; set; }
    public int QtyAvail { get; set; }
    public string ItemName { get; set; }
    public string LocName { get; set; }
    public DateTime TimeStamp { get; set; }
  }
}