using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class WayfairFeedDTO
  {
    public string SupplierId { get; set; }
    public string SupplierPartNo { get; set; }
    public int QtyOnHand { get; set; } // Actually QtyAvail
    public int QtyOnBackOrder { get; set; }
    public int QtyOnOrder { get; set; }
    public string ItemNextAvailDate { get; set; }
    public int Discountinued { get; set; }
    public string ProductNameOptions { get; set;}
  }
}
