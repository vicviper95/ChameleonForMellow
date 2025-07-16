namespace Chameleon.DTOs.Inventory
{
  public class InvSalesParetoRuleListItemDTO
  {
    public int ItemNoId { get; set; }
    public string ItemName { get; set; }
    public string AmazonOBABC { get; set; }
    public decimal AmazonOBWOS { get; set; }
    public int AmazonInvQty { get; set; }
    public string WayfairOBABC { get; set; }
    public decimal WayfairOBWOS { get; set; }
    public int WayfairInvQty { get; set; }
    public string WalmartABC { get; set; }
    public decimal WalmartWOS { get; set; }
    public string OthersABC { get; set; }
    public decimal OthersWOS { get; set; }
    public int countA { get; set; }
    public int countB { get; set; }
    public int countC { get; set; }
    public int CGQty { get; set; }
    //public double wos { get; set; }
    //public int totalSalesQty { get; set; }
  }
}
