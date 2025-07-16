using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class StatusOrder
    {
        public StatusOrder()
        {
            AdOrderDetails = new HashSet<AdOrderDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderStatusId { get; set; }
        public string OrderStatus { get; set; }

        public virtual ICollection<AdOrderDetail> AdOrderDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
