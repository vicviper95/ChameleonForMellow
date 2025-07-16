using Chameleon.Models;
using System.Collections.Generic;

namespace Chameleon.DTOs.Inventory
{
  public class GetMainslBancInvItemDetailDTO
  {
    public GetMainslBancInvItemDTO GetMainslBancInvItemDTO { get; set; }
    public bool DoNotFeedFromAll { get; set; }
    public bool DoNotFeedFromBanc { get; set; }
    public bool DoNotFeedFromMainsl { get; set; }
    public bool DoNotFeedFromSwcaft { get; set; }
    public bool DoNotFeedFromBasc { get; set; }
    public bool AmzSKUSpecific { get; set; }
    public bool AmzDoNotFeed { get; set; }
    public int AmzCustPercentage { get; set; }
    public string AmzCustPercentageTxt { get; set; }
    public int AmzCustZeroOutAt { get; set; }
    public bool BPMSKUSpecific { get; set; }
    public bool BPMDoNotFeed { get; set; }
    public int BPMCustPercentage { get; set; }
    public string BPMCustPercentageTxt { get; set; }
    public int BPMCustZeroOutAt { get; set; }
    public bool eBaySKUSpecific { get; set; }
    public bool eBayDoNotFeed { get; set; }
    public int eBayCustPercentage { get; set; }
    public string eBayCustPercentageTxt { get; set; }
    public int eBayCustZeroOutAt { get; set; }
    public bool HouzzSKUSpecific { get; set; }
    public bool HouzzDoNotFeed { get; set; }
    public int HouzzCustPercentage { get; set; }
    public string HouzzCustPercentageTxt { get; set; }
    public int HouzzCustZeroOutAt { get; set; }
    public bool HomeDepotSKUSpecific { get; set; }
    public bool HomeDepotDoNotFeed { get; set; }
    public int HomeDepotCustPercentage { get; set; }
    public string HomeDepotCustPercentageTxt { get; set; }
    public int HomeDepotCustZeroOutAt { get; set; }
    public bool TargetSKUSpecific { get; set; }
    public bool TargetDoNotFeed { get; set; }
    public int TargetCustPercentage { get; set; }
    public string TargetCustPercentageTxt { get; set; }
    public int TargetCustZeroOutAt { get; set; }
    public bool MellowSKUSpecific { get; set; }
    public bool MellowDoNotFeed { get; set; }
    public int MellowCustPercentage { get; set; }
    public string MellowCustPercentageTxt { get; set; }
    public int MellowCustZeroOutAt { get; set; }
    public bool OstSKUSpecific { get; set; }
    public bool OstDoNotFeed { get; set; }
    public int OstCustPercentage { get; set; }
    public string OstCustPercentageTxt { get; set; }
    public int OstCustZeroOutAt { get; set; }
    public bool WlmrtSKUSpecific { get; set; }
    public bool WlmrtDoNotFeed { get; set; }
    public int WlmrtCustPercentage { get; set; }
    public string WlmrtCustPercentageTxt { get; set; }
    public int WlmrtCustZeroOutAt { get; set; }
    public bool WyfrSKUSpecific { get; set; }
    public bool WyfrDoNotFeed { get; set; }
    public int WyfrCustPercentage { get; set; }
    public string WyfrCustPercentageTxt { get; set; }
    public int WyfrCustZeroOutAt { get; set; }
    public string remark { get; set; }
    public bool doesThisSKUhasSpecificRules { get; set;}
    public List<InvFeedsRemarkCategory> remarkList { get; set; }
  }
}
