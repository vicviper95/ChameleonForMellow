using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmtBulkCarrier
    {
        public int WmtBulkCarrierId { get; set; }
        public string Scac { get; set; }
        public string Carrier { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
