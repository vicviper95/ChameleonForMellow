using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ServerityType
    {
        public ServerityType()
        {
            AmzProductEligibilityDetails = new HashSet<AmzProductEligibilityDetail>();
        }

        public int ServerityTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzProductEligibilityDetail> AmzProductEligibilityDetails { get; set; }
    }
}
