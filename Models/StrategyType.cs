using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class StrategyType
    {
        public StrategyType()
        {
            AmzProductCampHists = new HashSet<AmzProductCampHist>();
        }

        public int StrategyTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzProductCampHist> AmzProductCampHists { get; set; }
    }
}
