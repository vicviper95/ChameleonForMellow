using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoBillStatus
    {
        public PoBillStatus()
        {
            PoBillTs = new HashSet<PoBillT>();
        }

        public int PoBillStatusId { get; set; }
        public string NsStatus { get; set; }
        public string Status { get; set; }

        public virtual ICollection<PoBillT> PoBillTs { get; set; }
    }
}
