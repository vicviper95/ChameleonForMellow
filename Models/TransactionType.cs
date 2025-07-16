using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            WfsInvtHists = new HashSet<WfsInvtHist>();
        }

        public int TransactionTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<WfsInvtHist> WfsInvtHists { get; set; }
    }
}
