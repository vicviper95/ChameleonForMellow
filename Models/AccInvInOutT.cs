using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AccInvInOutT
    {
        public AccInvInOutT()
        {
            AccInvInOutDs = new HashSet<AccInvInOutD>();
        }

        public int AccInvInOutTId { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<AccInvInOutD> AccInvInOutDs { get; set; }
    }
}
