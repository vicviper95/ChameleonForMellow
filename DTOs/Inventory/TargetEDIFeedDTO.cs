namespace Chameleon.DTOs.Inventory
{
  public class TargetEDIFeedDTO
  {
    public int itemNoId { get; set; }
    public string sku { get; set; }
    public int mainslQty { get; set; }
    //public int swcaftQty { get; set; }
    public int bancQty { get; set; }
    public int bascQty { get; set; }
    public int prsmCastQty { get; set; }
    public int zinusTracyQty { get; set; }
    public int zinusChsQty { get; set; }
    public string customerSku { get; set; }
    public string customerUpc { get; set; }
  }
}
