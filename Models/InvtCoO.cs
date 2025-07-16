using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvtCoO
    {
        public int InvtCoOId { get; set; }
        public int? GlimpactDId { get; set; }
        public int? InvWorksheetDId { get; set; }
        public int? PoDId { get; set; }
        public int Qty { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual GlimpactD GlimpactD { get; set; }
        public virtual InvWorksheetD InvWorksheetD { get; set; }
        public virtual PoD PoD { get; set; }
    }
}
