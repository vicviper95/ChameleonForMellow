using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class LandedCost
    {
        public int LandedCostId { get; set; }
        public int VendorBillDId { get; set; }
        public int? PoDId { get; set; }
        public int? ToDId { get; set; }
        public double Cost { get; set; }

        public virtual PoD PoD { get; set; }
        public virtual ToD ToD { get; set; }
        public virtual VendorBillD VendorBillD { get; set; }
    }
}
