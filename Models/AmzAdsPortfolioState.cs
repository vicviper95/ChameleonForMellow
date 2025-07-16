using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzAdsPortfolioState
    {
        public AmzAdsPortfolioState()
        {
            AmzPortfolioDetails = new HashSet<AmzPortfolioDetail>();
        }

        public int StateId { get; set; }
        public string State { get; set; }

        public virtual ICollection<AmzPortfolioDetail> AmzPortfolioDetails { get; set; }
    }
}
