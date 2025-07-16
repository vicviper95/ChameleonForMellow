using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsSKUDetailDTO
  {
    public GetMainslBancInvItemDetailDTO GetMainslBancInvItemDetailDTO { get; set; } 
    public int AmazonMainslQty { get; set; }
    public int AmazonBancQty { get; set; }
    public int WalmartMainslQty { get; set; }
    public int WalmartBancQty { get; set; }
    public int WayfairMainslQty { get; set; }
    public int WayfairBancQty { get; set; }
    public int OverstockMainslQty { get; set; }
    public int OverstockBancQty { get; set; }
    public int eBayMainslQty { get; set; }
    public int eBayBancQty { get; set; }
    public int BPMMainslQty { get; set; }
    public int BPMBancQty { get; set; }
    public int MellowMainslQty { get; set; }
    public int MellowBancQty { get; set; }
    public int HouzzMainslQty { get; set; }
    public int HouzzBancQty { get; set; }
  }
}
