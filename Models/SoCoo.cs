using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SoCoo
    {
        public int SoCooId { get; set; }
        public int SoDId { get; set; }
        public int PoDId { get; set; }
        public int Qty { get; set; }

        public virtual PoD PoD { get; set; }
        public virtual SoD SoD { get; set; }
    }
}
