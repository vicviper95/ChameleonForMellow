using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FobIncoTerm
    {
        public FobIncoTerm()
        {
            FobCostTracks = new HashSet<FobCostTrack>();
        }

        public int IncoTermId { get; set; }
        public string TermName { get; set; }

        public virtual ICollection<FobCostTrack> FobCostTracks { get; set; }
    }
}
