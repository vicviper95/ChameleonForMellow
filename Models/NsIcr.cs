using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsIcr
    {
        public NsIcr()
        {
            InvFeedsMrktSpecificSkus = new HashSet<InvFeedsMrktSpecificSku>();
            InvFeedsShopifies = new HashSet<InvFeedsShopify>();
        }

        public int IcrId { get; set; }
        public int CustomerId { get; set; }
        public string CustSku { get; set; }
        public int ItemNoId { get; set; }
        public string CustUpc { get; set; }
        public string CustAsin { get; set; }
        public string Gtin { get; set; }
        public DateTime? LaunchDate { get; set; }
        public int IsDisco { get; set; }
        public DateTime? DiscoDate { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public int? NsIntId { get; set; }
        public int? IsNew { get; set; }
        public DateTime? LastModKoT { get; set; }
        public int? LastModKoE { get; set; }
        public int? IsInvFeed { get; set; }
        public DateTime? LastFeedStatusUpdateDate { get; set; }
        public int? LastFeedStatusUpdateBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual Employee LastFeedStatusUpdateByNavigation { get; set; }
        public virtual ICollection<InvFeedsMrktSpecificSku> InvFeedsMrktSpecificSkus { get; set; }
        public virtual ICollection<InvFeedsShopify> InvFeedsShopifies { get; set; }
    }
}
