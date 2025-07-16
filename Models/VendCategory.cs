using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VendCategory
    {
        public VendCategory()
        {
            Vendors = new HashSet<Vendor>();
        }

        public int VendCatId { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
