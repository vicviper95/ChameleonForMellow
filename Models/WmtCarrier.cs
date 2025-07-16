using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmtCarrier
    {
        public int WmtCarId { get; set; }
        public string CarIdEdi { get; set; }
        public string CarIdApi { get; set; }
        public string CarDesc { get; set; }
        public int? CarrierId { get; set; }
        public int? ShipViaId { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? LastModTime { get; set; }
    }
}
