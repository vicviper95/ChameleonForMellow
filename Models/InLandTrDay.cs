using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InLandTrDay
    {
        public int InLandTrId { get; set; }
        public int? PortFromId { get; set; }
        public int DestWhId { get; set; }
        public int InLandTrDays { get; set; }
        public DateTime AddedDate { get; set; }
        public string PortName { get; set; }

        public virtual BpmLocation DestWh { get; set; }
        public virtual PortDest PortFrom { get; set; }
    }
}
