using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SpRecapChn
    {
        public SpRecapChn()
        {
            Customers = new HashSet<Customer>();
            SpRecapRos = new HashSet<SpRecapRo>();
        }

        public int SpRecapChnId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<SpRecapRo> SpRecapRos { get; set; }
    }
}
