using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsRmrkCtgry
    {
        public InvFeedsRmrkCtgry()
        {
            InvFeedsRemarks = new HashSet<InvFeedsRemark>();
        }

        public long InvFeedsRmrkCtgryId { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActivated { get; set; }
        public bool? DoNotFeedToAmazon { get; set; }
        public bool? DoNotFeedToeBay { get; set; }
        public bool? DoNotFeedToOverstock { get; set; }
        public bool? DoNotFeedToWalmart { get; set; }
        public bool? DoNotFeedToWayfair { get; set; }
        public bool? DoNotFeedToBpm { get; set; }
        public bool? DoNotFeedToMellow { get; set; }
        public bool? DoNotFeedToHouzz { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Description { get; set; }
        public bool? DoNotFeedToHomeDepot { get; set; }
        public bool? DoNotFeedToTarget { get; set; }
        public bool? DoNotFeedFromBanc { get; set; }
        public bool? DoNotFeedFromBasc { get; set; }
        public bool? DoNotFeedFromMainsl { get; set; }
        public bool? DoNotFeedFromSwcaft { get; set; }
        public int? CustomRatioAmazon { get; set; }
        public int? CustomRatioeBay { get; set; }
        public int? CustomRatioOverstock { get; set; }
        public int? CustomRatioWalmart { get; set; }
        public int? CustomRatioWayfair { get; set; }
        public int? CustomRatioBpm { get; set; }
        public int? CustomRatioMellow { get; set; }
        public int? CustomRatioHomeDepot { get; set; }
        public int? CustomRatioTarget { get; set; }
        public bool? DoNotFeedFromPrismCast { get; set; }
        public bool? DoNotFeedFromPrismCalt { get; set; }
        public bool? DoNotFeedFromZinusTracy { get; set; }
        public bool? DoNotFeedFromZinusChs { get; set; }

        public virtual Employee LastModifiedByNavigation { get; set; }
        public virtual ICollection<InvFeedsRemark> InvFeedsRemarks { get; set; }
    }
}
