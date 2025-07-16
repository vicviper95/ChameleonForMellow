using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmazonAdRepDetail
    {
        public AmazonAdRepDetail()
        {
            AmazonAdRepDetailHistories = new HashSet<AmazonAdRepDetailHistory>();
        }

        public int AdDetailId { get; set; }
        public int AdId { get; set; }
        public DateTime StartDate { get; set; }
        public string PortfolioName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string AdvertisedAsin { get; set; }
        public int IcrId { get; set; }

        public virtual AmazonAdReport Ad { get; set; }
        public virtual MkIcr Icr { get; set; }
        public virtual ICollection<AmazonAdRepDetailHistory> AmazonAdRepDetailHistories { get; set; }
    }
}
