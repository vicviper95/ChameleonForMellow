using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class eBayFeedDTO
  {
    public string eBaysku { get; set; }
    public string Status { get; set; }
    public int Qty { get; set; }
    public string Description { get; set; }
  }
}
