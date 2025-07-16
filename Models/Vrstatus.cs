using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Vrstatus
    {
        public Vrstatus()
        {
            VendorReturnTs = new HashSet<VendorReturnT>();
        }

        public int VrstatusId { get; set; }
        public string Stauts { get; set; }

        public virtual ICollection<VendorReturnT> VendorReturnTs { get; set; }
    }
}
