using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiBawB2cas2
    {
        public int As2Id { get; set; }
        public int InterchangeId { get; set; }
        public DateTime IcTime { get; set; }

        public virtual EdiBawB2cIc Interchange { get; set; }
    }
}
