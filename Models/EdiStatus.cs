using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiStatus
    {
        public EdiStatus()
        {
            EdiSeko846s = new HashSet<EdiSeko846>();
            EdiSeko940s = new HashSet<EdiSeko940>();
            EdiSeko945s = new HashSet<EdiSeko945>();
        }

        public int EdiStatusId { get; set; }
        public string EdiStatus1 { get; set; }

        public virtual ICollection<EdiSeko846> EdiSeko846s { get; set; }
        public virtual ICollection<EdiSeko940> EdiSeko940s { get; set; }
        public virtual ICollection<EdiSeko945> EdiSeko945s { get; set; }
    }
}
