using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TargetingType
    {
        public TargetingType()
        {
            AmzProductCampHists = new HashSet<AmzProductCampHist>();
        }

        public int TargetingTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzProductCampHist> AmzProductCampHists { get; set; }
    }
}
