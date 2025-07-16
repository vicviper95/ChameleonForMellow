using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class DrayageFeeD
    {
        public int DrayageFeeDId { get; set; }
        public int DrayageFeeTId { get; set; }
        public string Item { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public int? ContainerId { get; set; }
        public int? PoTId { get; set; }

        public virtual Container Container { get; set; }
        public virtual DrayageFoot DrayageFeeT { get; set; }
        public virtual PoT PoT { get; set; }
    }
}
