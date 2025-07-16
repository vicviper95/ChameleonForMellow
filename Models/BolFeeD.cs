using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BolFeeD
    {
        public int BolFeeDId { get; set; }
        public int BolFeeTId { get; set; }
        public string ChargeName { get; set; }
        public int Qty { get; set; }
        public string UoM { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsContCharge { get; set; }

        public virtual BolFoot BolFeeT { get; set; }
    }
}
