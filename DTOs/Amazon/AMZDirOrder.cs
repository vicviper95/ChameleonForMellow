
using Chameleon.DTOs.Amazon.order;
using System;

namespace Chameleon.DTOs.Amazon
{
  public class AMZDirOrder
  {
    public string purchaseOrderNumber { get; set; }
    public string purchaseOrderState { get; set; }
    public OrderDetails orderDetails { get; set; }
    public string nsSoNum { get; set; }
    public AMZDirOrder()
    {
      orderDetails = new OrderDetails();
    }
  }
}
