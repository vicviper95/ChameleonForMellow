using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayAs2
    {
        public int WayAs2Id { get; set; }
        public int EdiIcId { get; set; }

        public virtual WayB2pIc EdiIc { get; set; }
    }
}
