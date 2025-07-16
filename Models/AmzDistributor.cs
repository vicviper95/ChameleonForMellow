using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzDistributor
    {
        public AmzDistributor()
        {
            AmzObRptTs = new HashSet<AmzObRptT>();
        }

        public int Id { get; set; }
        public string Distributor { get; set; }

        public virtual ICollection<AmzObRptT> AmzObRptTs { get; set; }
    }
}
