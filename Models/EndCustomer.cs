using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EndCustomer
    {
        public EndCustomer()
        {
            Orders = new HashSet<Order>();
        }

        public int EndCustomerId { get; set; }
        public string FullName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AddrStatusId { get; set; }
        public DateTime? TimeRegistered { get; set; }
        public string Zone { get; set; }
        public string IsDcFor { get; set; }

        public virtual StatusAddr AddrStatus { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
