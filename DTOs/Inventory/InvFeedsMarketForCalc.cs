using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsMarketForCalc
  {
    public int CustomerId { get; set; }
    public int QtyBanc { get; set; }
    public int QtyMainsl { get; set; }
    public int Ratio { get; set; }
    public string custSKU { get; set; }
    public bool isDone { get; set; }
    public int Tier { get; set; }
  }
}
