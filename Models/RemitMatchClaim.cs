using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RemitMatchClaim
    {
        public int RemitMatchClaimId { get; set; }
        public string InvNo { get; set; }
        public int GlaccountId { get; set; }
        public string DocNo { get; set; }
        public int MarkitId { get; set; }

        public virtual GlAccount Glaccount { get; set; }
        public virtual Market Markit { get; set; }
    }
}
