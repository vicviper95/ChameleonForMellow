using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzPortfolio
    {
        public AmzPortfolio()
        {
            AmzPortfolioDetails = new HashSet<AmzPortfolioDetail>();
            AmzProductCampaigns = new HashSet<AmzProductCampaign>();
        }

        public long PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual ICollection<AmzPortfolioDetail> AmzPortfolioDetails { get; set; }
        public virtual ICollection<AmzProductCampaign> AmzProductCampaigns { get; set; }
    }
}
