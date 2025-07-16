using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class HouzzFeedDTO
  {
    public string BpmSku{ get; set; }
    public string HouzzSku { get; set; }
    public string UPC { get; set; }
    public int Qty { get; set; }
    public string Description { get; set; }
  }
}
