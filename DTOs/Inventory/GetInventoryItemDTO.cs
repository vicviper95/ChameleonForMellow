using System;
using System.ComponentModel.DataAnnotations;

namespace Chameleon.DTOs.Inventory
{
  public class GetInventoryItemDTO
  {
    [Key]
    public int InventoryItemId { get; set; }
    public int ItemNoId { get; set; }
    public string ItemName { get; set; }
    public int QtyOnHand { get; set; }
    public int QtyAvail { get; set; }
    public int LocId { get; set; }
    public string LocName { get; set; }
    public int NsIntId { get; set; }
    public DateTime TimeStamp { get; set; }
  }
}
