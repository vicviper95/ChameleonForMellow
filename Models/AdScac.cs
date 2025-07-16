using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdScac
    {
        public AdScac()
        {
            AdArns = new HashSet<AdArn>();
        }

        public int CarrierId { get; set; }
        public string Scac { get; set; }
        public string CarrierName { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? LastModTime { get; set; }

        public virtual ICollection<AdArn> AdArns { get; set; }
    }
}
