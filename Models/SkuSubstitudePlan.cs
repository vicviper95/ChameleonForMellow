using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SkuSubstitudePlan
    {
        public int SubstitudeId { get; set; }
        public DateTime TargetDate { get; set; }
        public int LocationId { get; set; }
        public int ItemFromId { get; set; }
        public int ItemToId { get; set; }
        public int QtyTotal { get; set; }
        public int QtySubsitituted { get; set; }
        public string Note { get; set; }

        public virtual KoItemno ItemFrom { get; set; }
        public virtual KoItemno ItemTo { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
