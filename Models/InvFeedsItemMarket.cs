using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsItemMarket
    {
        public long InvFeedsItemMarketId { get; set; }
        public int? CustomerId { get; set; }
        public int? Qty { get; set; }
        public int? Percentage { get; set; }
        public string CustSku { get; set; }
    }
}
