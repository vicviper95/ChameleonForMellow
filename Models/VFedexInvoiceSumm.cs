using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VFedexInvoiceSumm
    {
        public string OrigCustRefItem { get; set; }
        public string ChargeDesc { get; set; }
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
        public decimal? Mean { get; set; }
        public double? Std { get; set; }
    }
}
