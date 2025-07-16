using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class OverstockFeedDTO
  {
    public string SupplierSKU { get; set; }
    public int Qty { get; set; }
    public string WarehouseName { get; set; }
  }
}
