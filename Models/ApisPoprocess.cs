using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ApisPoprocess
    {
        public ApisPoprocess()
        {
            PoErrors = new HashSet<PoError>();
        }

        public int ProcessId { get; set; }
        public string ProcessType { get; set; }

        public virtual ICollection<PoError> PoErrors { get; set; }
    }
}
