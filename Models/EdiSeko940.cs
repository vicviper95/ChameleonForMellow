using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiSeko940
    {
        public int Seko940Id { get; set; }
        public int InterchangeId { get; set; }
        public int OrderId { get; set; }
        public int? EdiStateId { get; set; }
        public string EdiFileName { get; set; }
        public string AckFileName { get; set; }
        public int? AckInterchangeKey { get; set; }
        public int? EdiStatusId { get; set; }

        public virtual EdiFtpTxState EdiState { get; set; }
        public virtual EdiStatus EdiStatus { get; set; }
        public virtual EdiSekoBpmToSeko Interchange { get; set; }
        public virtual Order Order { get; set; }
    }
}
