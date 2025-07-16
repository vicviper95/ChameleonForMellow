using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BrandCampaign
    {
        public int BrandCampId { get; set; }
        public int? PortfolioId { get; set; }
        public string CampName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedCampaignTime { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
