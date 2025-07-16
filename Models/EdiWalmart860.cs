using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiWalmart860
    {
        public int Walmart860Id { get; set; }
        public int? EdiInterchangeId { get; set; }
        public int? AckInterchangeId { get; set; }
        public string EdiRxState { get; set; }
        public int? OrderId { get; set; }

        public virtual EdiBpmToWalmart AckInterchange { get; set; }
        public virtual Order Order { get; set; }
    }
}
