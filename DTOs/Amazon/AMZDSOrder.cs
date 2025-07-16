using Chameleon.DTOs.Amazon.orderDS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Amazon
{
  public class AMZDSOrder
  {
    public string purchaseOrderNumber { get; set; }
    public OrderDetailsDS orderDetails { get; set; }
    public string nsSoNum { get; set; }

    public AMZDSOrder()
    {
      orderDetails = new OrderDetailsDS();
    }

  }
}
