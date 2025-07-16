using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CustomerPo
    {
        public CustomerPo()
        {
            CustomerPodetails = new HashSet<CustomerPodetail>();
        }

        public int CustomerPoId { get; set; }
        public string Ponumber { get; set; }
        public DateTime ShipWindowEnd { get; set; }
        public DateTime ShipWindowStart { get; set; }
        public DateTime? LastModDateTime { get; set; }
        public DateTime? AddedDateTime { get; set; }
        public string VendorCode { get; set; }
        public byte? IsClosed { get; set; }

        public virtual ICollection<CustomerPodetail> CustomerPodetails { get; set; }
    }
}
