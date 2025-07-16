using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TimeFrame
    {
        public TimeFrame()
        {
            AmzObRptTs = new HashSet<AmzObRptT>();
        }

        public int Id { get; set; }
        public string TimeFrame1 { get; set; }

        public virtual ICollection<AmzObRptT> AmzObRptTs { get; set; }
    }
}
