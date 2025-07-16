using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdBolRule
    {
        public int BolRuleId { get; set; }
        public int MaxPallet { get; set; }
        public int MaxCf { get; set; }
        public int BancMaxQty { get; set; }
    }
}
