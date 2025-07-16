using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayfairProductReview
    {
        public int ReviewNumber { get; set; }
        public string SellerUnqId { get; set; }
        public int Star { get; set; }
        public string Review { get; set; }
        public DateTime Date { get; set; }
        public string CustomerInfo { get; set; }
    }
}
