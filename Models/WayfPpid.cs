using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayfPpid
    {
        public int WayfPpidId { get; set; }
        public int IcrId { get; set; }
        public int? SizePpid1 { get; set; }
        public int? ColorPpid2 { get; set; }
        public DateTime? AddedTime { get; set; }

        public virtual MkIcr Icr { get; set; }
    }
}
