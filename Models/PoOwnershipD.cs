using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoOwnershipD
    {
        public int PoOwnershipDId { get; set; }
        public int PoOwnershipTId { get; set; }
        public int? NsIntId { get; set; }
        public int PoDId { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal LineTotal { get; set; }

        public virtual PoD PoD { get; set; }
        public virtual PoOwnershipT PoOwnershipT { get; set; }
    }
}
