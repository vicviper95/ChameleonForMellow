using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsRemarkSKUGroupDTO
  {
    public int ItemNoId { get; set; }
    public bool IsInGroup { get; set; }
    public string remarkGroup { get; set; }
    public string remarkGroupList { get; set; }
    public string BpmSKU { get; set; }
    public string Description { get; set; }
    public bool IsEdited { get; set; }
  }
}
