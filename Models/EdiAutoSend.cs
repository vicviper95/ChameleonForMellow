using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiAutoSend
    {
        public int AutoSendId { get; set; }
        public int EpId { get; set; }
        public byte FgcId { get; set; }
        public bool IsAutoOn { get; set; }
        public int? CustomerId { get; set; }
    }
}
