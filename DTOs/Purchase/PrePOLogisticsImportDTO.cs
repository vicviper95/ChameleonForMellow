namespace Chameleon.DTOs.Purchase
{
  public class PrePOLogisticsImportDTO
  {

    public string internalPONo { get; set; }
    public string sku { get; set; }
    public int? QtyConfirmed { get; set; }
    public string ChosenVendor { get; set; }
    public string AcceptanceNote { get; set; }
    public string ETD_C { get; set; }
    public string CompleteNote { get; set; }
    public string MustETADate { get; set; }
    }
}
