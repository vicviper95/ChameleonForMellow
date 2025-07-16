using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ContFeeD
    {
        public int ContFeeDId { get; set; }
        public int ContFeeTId { get; set; }
        public int? PoDId { get; set; }
        public int? ToDId { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public string ProvTariff { get; set; }
        public decimal? ProvDutyRate { get; set; }
        public string Tariff { get; set; }
        public decimal? TariffDutyRate { get; set; }

        public virtual ContFoot ContFeeT { get; set; }
        public virtual PoD PoD { get; set; }
        public virtual ToD ToD { get; set; }
    }
}
