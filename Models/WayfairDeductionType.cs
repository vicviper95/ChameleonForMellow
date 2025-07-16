using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayfairDeductionType
    {
        public WayfairDeductionType()
        {
            WayfairDeductions = new HashSet<WayfairDeduction>();
        }

        public int DeductionTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WayfairDeduction> WayfairDeductions { get; set; }
    }
}
