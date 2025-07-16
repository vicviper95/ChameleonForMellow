using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoDCont
    {
        public int PoDContId { get; set; }
        public int PoDId { get; set; }
        public int? ContainerId { get; set; }
        public int QtyContExp { get; set; }
        public int QtyContRcvd { get; set; }
        public int? QtyContDmg { get; set; }
        public int? QtyOutstand { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? LastModTime { get; set; }
        public int? NsLineId { get; set; }

        public virtual Container Container { get; set; }
        public virtual PoD PoD { get; set; }
    }
}
