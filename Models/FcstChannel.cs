using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstChannel
    {
        public FcstChannel()
        {
            Customers = new HashSet<Customer>();
            ItemAbcCms = new HashSet<ItemAbcCm>();
            ItemAbcPcs = new HashSet<ItemAbcPc>();
        }

        public int FcstChannelId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<ItemAbcCm> ItemAbcCms { get; set; }
        public virtual ICollection<ItemAbcPc> ItemAbcPcs { get; set; }
    }
}
