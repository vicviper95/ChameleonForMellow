using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiSekoBpmToSeko
    {
        public EdiSekoBpmToSeko()
        {
            EdiSeko940s = new HashSet<EdiSeko940>();
            EdiSeko945s = new HashSet<EdiSeko945>();
        }

        public int InterchangeId { get; set; }
        public DateTime IcDateTime { get; set; }
        public string FgcName { get; set; }

        public virtual ICollection<EdiSeko940> EdiSeko940s { get; set; }
        public virtual ICollection<EdiSeko945> EdiSeko945s { get; set; }
    }
}
