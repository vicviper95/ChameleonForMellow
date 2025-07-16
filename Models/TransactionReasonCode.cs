using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TransactionReasonCode
    {
        public TransactionReasonCode()
        {
            WfsInvtHists = new HashSet<WfsInvtHist>();
        }

        public int TransactionReasonCodeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<WfsInvtHist> WfsInvtHists { get; set; }
    }
}
