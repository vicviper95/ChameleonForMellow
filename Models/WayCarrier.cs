using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayCarrier
    {
        public int WayCarId { get; set; }
        public string CarCode { get; set; }
        public string CarSpeed { get; set; }
        public int ShipViaId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModTime { get; set; }

        public virtual ShipVium ShipVia { get; set; }
    }
}
