using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiBpmToWalmart
    {
        public int InterchangeId { get; set; }
        public DateTime? IcTime { get; set; }
        public string EdiStr { get; set; }
    }
}
