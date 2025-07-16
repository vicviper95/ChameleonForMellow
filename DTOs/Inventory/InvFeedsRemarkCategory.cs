using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class InvFeedsRemarkCategory
  {
    public long categoryId { get; set; }
    public string categoryName { get; set; }
    public bool isActivatedOnThisSKU { get; set; }
    public bool MainslDoNotFeed { get; set; }
    public bool SwcaftDoNotFeed { get; set; }
    public bool BancDoNotFeed { get; set; }
    public bool BascDoNotFeed { get; set; }
    public bool PrismCastDoNotFeed { get; set; }
    public bool PrismCaltDoNotFeed { get; set; }
    public bool ZinusTracyDoNotFeed { get; set; }
    public bool ZinusChsDoNotFeed { get; set; }
    public bool AmazonDoNotFeed { get; set; }
    public bool eBayDoNotFeed { get; set; }
    public bool WayfairDoNotFeed { get; set; }
    public bool OverstockDoNotFeed { get; set; }
    public bool WalmartDoNotFeed { get; set; }
    public bool HouzzDoNotFeed { get; set; }
    public bool BPMDoNotFeed { get; set; }
    public bool MellowDoNotFeed { get; set; }
    public bool HomeDepotDoNotFeed { get; set; }
    public bool TargetDoNotFeed { get; set; }
    public int CustomRatioAmazon { get; set; }
    public int CustomRatioeBay { get; set; }
    public int CustomRatioWayfair { get; set; }
    public int CustomRatioOverstock { get; set; }
    public int CustomRatioWalmart { get; set; }
    public int CustomRatioBPM { get; set; }
    public int CustomRatioMellow { get; set; }
    public int CustomRatioHomeDepot { get; set; }
    public int CustomRatioTarget { get; set; }
    public string LastModifiedBy { get; set; }
    public string LastModifiedDate { get; set; }
  }
}
