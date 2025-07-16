using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ToFfd
    {
        public int ToFfdId { get; set; }
        public int? NsIntId { get; set; }
        public int ToFftId { get; set; }
        public int ToDId { get; set; }
        public int Qty { get; set; }

        public virtual ToD ToD { get; set; }
        public virtual ToFft ToFft { get; set; }
    }
}
