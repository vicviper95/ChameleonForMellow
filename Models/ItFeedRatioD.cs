using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItFeedRatioD
    {
        public int FeedRatioDId { get; set; }
        public int FeedRatioTId { get; set; }
        public int CustId { get; set; }
        public int CustRatio { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ItFeedRatioT FeedRatioT { get; set; }
    }
}
