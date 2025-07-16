using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class AmazonFeedDTO
  {
    public int itemSeq { get; set; }
    public string SKU { get; set; }
    public string UPC { get; set; }
    public string ASIN { get; set; } 
    public string Title { get; set; }
    public string WarehouseId { get; set; }
    public string WarehouseName { get; set; }
    public int QtyAvail { get; set; }
    public string Status { get; set; }
  }
}
