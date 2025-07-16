using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiSeko846
    {
        public int Seko846Id { get; set; }
        public int? InterchangeId { get; set; }
        public string EdiFileName { get; set; }
        public int? AckInterchangeKey { get; set; }
        public string AckFileName { get; set; }
        public int? EdiStateId { get; set; }
        public int? EdiStatusId { get; set; }

        public virtual EdiFtpRxState EdiState { get; set; }
        public virtual EdiStatus EdiStatus { get; set; }
    }
}
