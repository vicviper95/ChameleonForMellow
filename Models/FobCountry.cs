using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FobCountry
    {
        public FobCountry()
        {
            FobCostTracks = new HashSet<FobCostTrack>();
        }

        public int CountryId { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<FobCostTrack> FobCostTracks { get; set; }
    }
}
