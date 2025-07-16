using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CarrierCharge
    {
        public int CarChargeId { get; set; }
        public int ShipLineId { get; set; }
        public decimal? ChasisFree { get; set; }
        public string ChasisDayQaul { get; set; }
        public short DetFreeDays { get; set; }
        public string DetDayQual { get; set; }

        public virtual ShipLine ShipLine { get; set; }
    }
}
