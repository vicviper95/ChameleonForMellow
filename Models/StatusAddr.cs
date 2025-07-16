using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class StatusAddr
    {
        public StatusAddr()
        {
            EndCustomers = new HashSet<EndCustomer>();
        }

        public int AddrStatusId { get; set; }
        public string AddrStatus { get; set; }

        public virtual ICollection<EndCustomer> EndCustomers { get; set; }
    }
}
