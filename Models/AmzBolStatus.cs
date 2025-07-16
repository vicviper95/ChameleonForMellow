using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzBolStatus
    {
        public AmzBolStatus()
        {
            AdArns = new HashSet<AdArn>();
        }

        public int BolStatusId { get; set; }
        public string BolStatus { get; set; }

        public virtual ICollection<AdArn> AdArns { get; set; }
    }
}
