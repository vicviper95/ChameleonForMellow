using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ServingStatusType
    {
        public ServingStatusType()
        {
            AmzProductCampHists = new HashSet<AmzProductCampHist>();
        }

        public int ServingStatusId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzProductCampHist> AmzProductCampHists { get; set; }
    }
}
