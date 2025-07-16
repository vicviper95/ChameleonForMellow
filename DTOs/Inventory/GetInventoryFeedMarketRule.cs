using System;

namespace Chameleon.DTOs.Inventory
{
  public class GetInventoryFeedMarketRule
  {
    public int InvFeedRuleId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int ZeroOutAt { get; set; }
    public int CustomFeedRatio { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedTime { get; set; }
    public Boolean IsActivated { get; set; }
    public string CustomFeedRatioText { get; set; }
  }
}
