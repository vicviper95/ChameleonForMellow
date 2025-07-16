using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CampStateType
    {
        public CampStateType()
        {
            AmzProductCampHists = new HashSet<AmzProductCampHist>();
        }

        public int CampStateTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzProductCampHist> AmzProductCampHists { get; set; }
    }
}
