using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Amazon.order
{
  public class Items
  {
    public string itemSequenceNumber { get; set; }
    public string amazonProductIdentifier { get; set; }
    public string vendorProductIdentifier { get; set; }
    public OrderedQuantity orderedQuantity { get; set; }
    public bool isBackOrderAllowed { get; set; }
    public Prices netCost { get; set; }
    public Prices listPrice { get; set; }
    public int bpmNSIntId { get; set; }
    public Items()
    {
      orderedQuantity = new OrderedQuantity();
    }
  }

  public class OrderedQuantity
  {
    public int amount { get; set; }
    public string unitOfMeasure { get; set; }
    public int unitSize { get; set; }
  }

}
