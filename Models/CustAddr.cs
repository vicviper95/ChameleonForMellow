using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CustAddr
    {
        public int CustAddrId { get; set; }
        public int CustomerId { get; set; }
        public string CustName { get; set; }
        public string RetAddr1 { get; set; }
        public string RetAddr2 { get; set; }
        public string RetAddr3 { get; set; }
        public string RetCity { get; set; }
        public string RetState { get; set; }
        public string RetZip { get; set; }
        public string RetCountry { get; set; }
        public string BillAddr1 { get; set; }
        public string BillAddr2 { get; set; }
        public string BillAddr3 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillZip { get; set; }
        public string BillCountry { get; set; }
        public string PhoneNo { get; set; }
        public int? LocationId { get; set; }
        public int? CarrierId { get; set; }

        public virtual ShipCarrier Carrier { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
