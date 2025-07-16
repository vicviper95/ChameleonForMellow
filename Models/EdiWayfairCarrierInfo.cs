using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiWayfairCarrierInfo
    {
        public int UniqId { get; set; }
        public string Scac { get; set; }
        public string SpeedCode { get; set; }
        public int ShipViaId { get; set; }

        public virtual ShipVium ShipVia { get; set; }
    }
}
