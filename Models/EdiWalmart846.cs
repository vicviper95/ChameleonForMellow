using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiWalmart846
    {
        public int Walmart846Id { get; set; }
        public int? EdiInterchangeId { get; set; }
        public int? AckInterchangeId { get; set; }
        public string EdiTxState { get; set; }

        public virtual EdiBpmToWalmart EdiInterchange { get; set; }
    }
}
