using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiWalmart856
    {
        public int Walmart856Id { get; set; }
        public int? EdiInterchangeId { get; set; }
        public int? AckInterchangeId { get; set; }
        public string EdiTxState { get; set; }
        public int? OrderId { get; set; }

        public virtual EdiBpmToWalmart EdiInterchange { get; set; }
        public virtual Order Order { get; set; }
    }
}
