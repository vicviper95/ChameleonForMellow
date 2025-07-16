using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CustBillAddr
    {
        public int CustBillAddrId { get; set; }
        public int CustomerId { get; set; }
        public int? CarrierId { get; set; }
        public int? LocationId { get; set; }
        public string Name { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public virtual ShipCarrier Carrier { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
