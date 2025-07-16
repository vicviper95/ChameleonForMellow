using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class BpmMellowFeedsListItemImportDTO
  {
    public string Handle { get; set; }
    public string Title { get; set; }
    public string Option1Name { get; set; }
    public string Option1Value { get; set; }
    public string Option2Name { get; set; }
    public string Option2Value { get; set; }
    public string Option3Name { get; set; }
    public string Option3Value { get; set; }
    public string SKU { get; set; }
    public string HSCode { get; set; }
    public string COO { get; set; }
  }
}
