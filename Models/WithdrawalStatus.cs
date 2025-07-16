using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WithdrawalStatus
    {
        public WithdrawalStatus()
        {
            KoCoDs = new HashSet<KoCoD>();
        }

        public int StatusId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<KoCoD> KoCoDs { get; set; }
    }
}
