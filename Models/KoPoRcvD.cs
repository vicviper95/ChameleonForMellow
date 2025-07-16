using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoPoRcvD
    {
        public int KoRcvDId { get; set; }
        public int KoRcvTId { get; set; }
        public int PoDId { get; set; }
        public int QtyRcvd { get; set; }
        public DateTime LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }

        public virtual KoPoRcvT KoRcvT { get; set; }
        public virtual PoD PoD { get; set; }
    }
}
