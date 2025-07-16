using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoPackD
    {
        public int PoPackDId { get; set; }
        public int PoPackTId { get; set; }
        public int PoDId { get; set; }
        public int QtyPacked { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }

        public virtual PoD PoD { get; set; }
        public virtual PoPackT PoPackT { get; set; }
    }
}
