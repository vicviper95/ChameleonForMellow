using System;

namespace Chameleon.DTOs.Inventory
{
    public class HomeDepotFeedDTO
    {
    public int itemNoId { get; set; } 
    public string alwaysIn { get; set; }
    public string homeDepotSku { get; set; }
    public string sku { get; set; }
    public string availability { get; set; }
    public int totalQtyOnHand { get; set; }
    public string homeDepotAssignedSku { get; set; }
    public string homeDepotMerchantName { get; set; }
    public string upc { get; set;}
    public string warehouse01Id { get; set; }
    public int warehouse01Qty { get; set; }
    public string warehouse01NextAvailQty { get; set; }
    public string warehouse01NextAvailDate { get; set; }
    public string warehouse02Id { get; set; }
    public int warehouse02Qty { get; set; }
    public string warehouse02NextAvailQty { get; set; }
    public string warehouse02NextAvailDate { get; set; }
    public string warehouse03Id { get; set; }
    public int warehouse03Qty { get; set; }
    public string warehouse03NextAvailQty { get; set; }
    public string warehouse03NextAvailDate { get; set; }
    public string warehouse04Id { get; set; }
    public int warehouse04Qty { get; set; }
    public string warehouse04NextAvailQty { get; set; }
    public string warehouse04NextAvailDate { get; set; }
    public string warehouse05Id { get; set; }
    public int warehouse05Qty { get; set; }
    public string warehouse05NextAvailQty { get; set; }
    public string warehouse05NextAvailDate { get; set; }
  }
}
