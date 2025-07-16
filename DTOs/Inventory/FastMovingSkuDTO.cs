using System.Security.Permissions;

namespace Chameleon.DTOs.Inventory
{
  public class FastMovingSkuDTO
  {
    public int FstMvRepDetailId { get; set; }
    public int ItemNoId { get; set; }
    public string ItemName { get; set; }
    public int QtyAvailMainsl { get; set; }
    public int QtyAvailZinusTracy { get; set; }
    public int QtyAvailZinusChs { get; set; }
    public int StagePOQtyMainsl { get; set; }
    public int StagePOQtyZinusTracy { get; set; }
    public int StagePOQtyZinusChs { get; set; }
    public int SoldQtyOfLastWeek { get; set; }
    public int TotalQty { get; set; }
    public int TotalQtyStagePO { get; set; }
    public int TotalQtySales { get; set; }
    public bool IsIncludedNotification { get; set; }
    public bool IsFlagged { get; set; }
  }
}
