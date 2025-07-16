using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TransactionLocation
    {
        public TransactionLocation()
        {
            WfsInvtHists = new HashSet<WfsInvtHist>();
        }

        public int TransactionLocationId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<WfsInvtHist> WfsInvtHists { get; set; }
    }
}
