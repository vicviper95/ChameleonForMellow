using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ToRcvD
    {
        public int ToRcvDId { get; set; }
        public int? NsIntId { get; set; }
        public int ToRcvTId { get; set; }
        public int ToDId { get; set; }
        public int Qty { get; set; }
        public bool? IsValid { get; set; }

        public virtual ToD ToD { get; set; }
        public virtual ToRcvT ToRcvT { get; set; }
    }
}
