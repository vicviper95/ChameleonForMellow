using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsStockItemDetailDTO
  {
    public long InventoryItemId { get; set; }
    public int ItemNoId { get; set; }
    public string ItemName { get; set; }
    public int QtyOnHandMainsl { get; set; }
    public int QtyAvailMainsl { get; set; }
    public int QtyOnHandBanc { get; set; }
    public int QtyAvailBanc { get; set; }
    //public int QtyOnHandSwcaft { get; set; }
    //public int QtyAvailSwcaft { get; set; }
    public int QtyOnHandBasc { get; set; }
    public int QtyAvailBasc { get; set; }
    public int QtyOnHandPrismCast { get; set; }
    public int QtyAvailPrismCast { get; set; }
    public int QtyOnHandPrismCalt { get; set; }
    public int QtyAvailPrismCalt { get; set; }
    public int QtyOnHandZinusTracy { get; set; }
    public int QtyAvailZinusTracy { get; set; }
    public int QtyOnHandZinusChs { get; set; }
    public int QtyAvailZinusChs { get; set; }
    public int StagePOOrigBanc { get; set; }
    public int StagePOOrigBasc { get; set; }
    public int StagePOOrigMainsl { get; set; }
    //public int StagePOOrigSwcaft { get; set; }
    public int StagePOOrigPrismCast { get; set; }
    public int StagePOOrigPrismCalt { get; set; }
    public int StagePOOrigZinusTracy { get; set; }
    public int StagePOOrigZinusChs { get; set; }
    public int StagePOModBanc { get; set; }
    public int StagePOModBasc { get; set; }
    public int StagePOModMainsl { get; set; }
    public int StagePOModSwcaft { get; set; }
    public int StagePOModPrismCast { get; set; }
    public int StagePOModPrismCalt { get; set; }
    public int StagePOModZinusTracy { get; set; }
    public int StagePOModZinusChs { get; set; }
    public int StagePOModBanc60 { get; set; }
    public int StagePOModBasc60 { get; set; }
    public int StagePOModMainsl60 { get; set; }
    //public int StagePOModSwcaft60 { get; set; }
    public int StagePOModPrismCast60 { get; set; }
    public int StagePOModPrismCalt60 { get; set; }
    public int StagePOModZinusTracy60 { get; set; }
    public int StagePOModZinusChs60 { get; set; }
    public int StagePOModBanc90 { get; set; }
    public int StagePOModBasc90 { get; set; }
    public int StagePOModMainsl90 { get; set; }
    //public int StagePOModSwcaft90 { get; set; }
    public int StagePOModPrismCast90 { get; set; }
    public int StagePOModPrismCalt90 { get; set; }
    public int StagePOModZinusTracy90 { get; set; }
    public int StagePOModZinusChs90 { get; set; }
    public int InvBascItemId { get; set; }
    public int InvBancItemId { get; set; }
    public int InvMainslItemId { get; set; }
    public int InvSWCAFTItemId { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime LastModifiedTime { get; set; }
    public string LastModifiedBy { get; set; }
    public Boolean isSet { get; set; }
    public int beforeBOMQtyAvailMainsl { get; set; }
    public int beforeBOMQtyAvailBanc { get; set; }
    //public int beforeBOMQtyAvailSwcaft { get; set; }
    public int beforeBOMQtyAvailBasc { get; set; }
    public bool DoNotFeedFromAll { get; set; }
    public bool DoNotFeedFromBanc { get; set; }
    public bool DoNotFeedFromMainsl { get; set; }
   // public bool DoNotFeedFromSwcaft { get; set; }
    public bool DoNotFeedFromBasc { get; set; }
    public bool DoNotFeedFromPrismCast { get; set; }
    public bool DoNotFeedFromPrismCalt { get; set; }
    public bool DoNotFeedFromZinusTracy { get; set; }
    public bool DoNotFeedFromZinusChs { get; set; }
    public bool AmzDoNotFeed { get; set; }
    public bool BPMDoNotFeed { get; set; }
    public bool eBayDoNotFeed { get; set; }
    public bool HouzzDoNotFeed { get; set; }
    public bool MellowDoNotFeed { get; set; }
    public bool OstDoNotFeed { get; set; }
    public bool WlmrtDoNotFeed { get; set; }
    public bool WyfrDoNotFeed { get; set; }
    public bool HomeDepotDoNotFeed { get; set; }
    public bool TargetDoNotFeed { get; set; }
    public string Remark { get; set;}
    public int CheckBackOrderLeadTimeMainsl { get; set; }
    //public int CheckBackOrderLeadTimeSwcaft { get; set; }
    public int CheckBackOrderLeadTimeBanc { get; set; }
    public int CheckBackOrderLeadTimeBasc { get; set; }
    public int CheckBackOrderLeadTimePrismCastId { get; set; }
    public int CheckBackOrderLeadTimePrismCaltId { get; set; }
    public int CheckBackOrderLeadTimeZinusTracyId { get; set; }
    public int CheckBackOrderLeadTimeZinusChsId { get; set; }
    public bool DoNotFeedLessThan10 { get; set; }
    public List<InvFeedsRemarkCategory> remarkList { get; set; }
  }
}
