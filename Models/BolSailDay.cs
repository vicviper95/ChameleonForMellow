using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BolSailDay
    {
        public int SailDayId { get; set; }
        public int PortOriginId { get; set; }
        public int PortDestId { get; set; }
        public int SailingDays { get; set; }
        public DateTime? AddedDate { get; set; }

        public virtual PortDest PortDest { get; set; }
        public virtual PortOrigin PortOrigin { get; set; }
    }
}
