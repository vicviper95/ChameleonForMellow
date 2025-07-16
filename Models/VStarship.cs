using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VStarship
    {
        public string TrackingNumber { get; set; }
        public string MasterTrackingId { get; set; }
        public string Ponumber { get; set; }
        public string Description { get; set; }
        public int? ItemnoId { get; set; }
        public string AccountNumber { get; set; }
        public string CarrierInterfaceId { get; set; }
        public string OrderNumber { get; set; }
    }
}
