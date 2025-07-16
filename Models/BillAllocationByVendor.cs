using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BillAllocationByVendor
    {
        public int BillAllocationByVendorId { get; set; }
        public int VendorId { get; set; }
        public int VendorAllocationMethodId { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual VendorAllocationMethod VendorAllocationMethod { get; set; }
    }
}
