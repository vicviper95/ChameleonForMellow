using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfsChildShipmentId
    {
        public int ChildId { get; set; }
        public int ParentId { get; set; }
        public string ShipmentId { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual WfsParentShipmetId Parent { get; set; }
    }
}
