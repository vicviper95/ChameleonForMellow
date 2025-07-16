using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmazonAdReport
    {
        public AmazonAdReport()
        {
            AmazonAdRepDetails = new HashSet<AmazonAdRepDetail>();
        }

        public int AdId { get; set; }
        public DateTime EndDate { get; set; }
        public string CampaignName { get; set; }
        public string AdGroupName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsWeek { get; set; }
        public int? SponsoredTypeId { get; set; }

        public virtual AmzAdsSponsoredType SponsoredType { get; set; }
        public virtual ICollection<AmazonAdRepDetail> AmazonAdRepDetails { get; set; }
    }
}
