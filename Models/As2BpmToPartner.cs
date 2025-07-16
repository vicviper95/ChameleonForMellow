using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class As2BpmToPartner
    {
        public int As2BpmId { get; set; }
        public DateTime IcTime { get; set; }
        public int? InterchangeId { get; set; }

        public virtual BpmToWayfairIc Interchange { get; set; }
    }
}
