using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayfairDeductionStatus
    {
        public WayfairDeductionStatus()
        {
            WayfairDeductions = new HashSet<WayfairDeduction>();
        }

        public int DeductionStatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WayfairDeduction> WayfairDeductions { get; set; }
    }
}
