using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ShipAcct
    {
        public int ShipActId { get; set; }
        public int CustomerId { get; set; }
        public int ShipFrWhId { get; set; }
        public int CarrierId { get; set; }
        public string ShipAcctNo { get; set; }
        public string BillAcctNo { get; set; }

        public virtual ShipCarrier Carrier { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual BpmLocation ShipFrWh { get; set; }
    }
}
