using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzPortfolioDetail
    {
        public int PortfolioDId { get; set; }
        public bool Inbuget { get; set; }
        public int State { get; set; }
        public DateTime AddedTime { get; set; }
        public long PortfolioTId { get; set; }

        public virtual AmzPortfolio PortfolioT { get; set; }
        public virtual AmzAdsPortfolioState StateNavigation { get; set; }
    }
}
