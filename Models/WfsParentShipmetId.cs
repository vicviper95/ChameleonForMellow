using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfsParentShipmetId
    {
        public WfsParentShipmetId()
        {
            WfsChildShipmentIds = new HashSet<WfsChildShipmentId>();
        }

        public int ParentId { get; set; }
        public string ShipmentId { get; set; }
        public bool IsSplited { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual ICollection<WfsChildShipmentId> WfsChildShipmentIds { get; set; }
    }
}
