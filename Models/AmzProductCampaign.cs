using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzProductCampaign
    {
        public AmzProductCampaign()
        {
            AmzProductCampHists = new HashSet<AmzProductCampHist>();
        }

        public long ProdCampId { get; set; }
        public string CampName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime CreatedCampaignTime { get; set; }
        public long? PortfolioId { get; set; }

        public virtual AmzPortfolio Portfolio { get; set; }
        public virtual ICollection<AmzProductCampHist> AmzProductCampHists { get; set; }
    }
}
