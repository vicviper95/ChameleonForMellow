using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class HdpCarrier
    {
        public int HdpCarId { get; set; }
        public string Routing { get; set; }
        public string ServLevel { get; set; }
        public int ShipViaId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModTime { get; set; }
        public string RetCode { get; set; }
    }
}
