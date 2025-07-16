using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdVendorCode
    {
        public AdVendorCode()
        {
            AdOrders = new HashSet<AdOrder>();
        }

        public int VendorCodeId { get; set; }
        public string VendorCode { get; set; }
        public string Note { get; set; }

        public virtual ICollection<AdOrder> AdOrders { get; set; }
    }
}
