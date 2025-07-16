using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VendorAllocationMethod
    {
        public VendorAllocationMethod()
        {
            BillAllocationByVendors = new HashSet<BillAllocationByVendor>();
        }

        public int VendorAllocationMethodId { get; set; }
        public string Method { get; set; }

        public virtual ICollection<BillAllocationByVendor> BillAllocationByVendors { get; set; }
    }
}
