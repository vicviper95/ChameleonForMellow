using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItFeedRatioT
    {
        public ItFeedRatioT()
        {
            ItFeedRatioDs = new HashSet<ItFeedRatioD>();
        }

        public int FeedRatioTId { get; set; }
        public int ItemNoId { get; set; }
        public int MasterRatio { get; set; }
        public int YrSalesQty { get; set; }
        public int YrSalesWks { get; set; }
        public int YrAvgWkQty { get; set; }
        public int LowQWosAt { get; set; }
        public int LowQQtyAt { get; set; }
        public int LowQDfCustId { get; set; }
        public int LowQDfRatio { get; set; }
        public int NormQDfRatio { get; set; }
        public int? ManualCustId { get; set; }
        public int? ManualRatio { get; set; }
        public bool? IsAutoModeOn { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual Customer LowQDfCust { get; set; }
        public virtual Customer ManualCust { get; set; }
        public virtual ICollection<ItFeedRatioD> ItFeedRatioDs { get; set; }
    }
}
