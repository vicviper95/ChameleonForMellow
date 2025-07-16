using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Amazon.orderDS
{
  public class ItemDetail
  {
    public int itemSequenceNumber { get; set; }
    public string buyerProductIdentifier { get; set; }
    public string vendorProductIdentifier { get; set; }
    public string title { get; set; }
    public OrderedQuantity orderedQuantity { get; set; }
    public Prices netPrice { get; set; }
    public Tax taxDetails { get; set; }
    public Prices totalPrice { get; set; }
    public ItemDetail()
    {
      orderedQuantity = new OrderedQuantity();
    }
  }
}
