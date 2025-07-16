using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdOrderDetail
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public int ItemNoId { get; set; }
        public int QtySubmitted { get; set; }
        public int QtyAccepted { get; set; }
        public int QtyShipped { get; set; }
        public int QtyBalance { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderStatusId { get; set; }
        public string Note { get; set; }
        public int QtyPreCancel { get; set; }
        public int QtyPostCancel { get; set; }
        public int? IsClosed { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? ModifiedEmp { get; set; }
        public int? NsIntId { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual AdOrder Order { get; set; }
        public virtual StatusOrder OrderStatus { get; set; }
    }
}
