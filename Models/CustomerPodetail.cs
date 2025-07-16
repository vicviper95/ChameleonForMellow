using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CustomerPodetail
    {
        public int CustomerPodetailId { get; set; }
        public int CustomerPoId { get; set; }
        public int ItemNoId { get; set; }
        public int? QtySubmitted { get; set; }
        public int QtyAccepted { get; set; }
        public int? QtyTobeShipped { get; set; }
        public int? QtyReceived { get; set; }
        public int QtyOutstanding { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime? ExpectedShipDate { get; set; }
        public byte? IsCanceledButShipped { get; set; }
        public byte? BackOrdered { get; set; }
        public DateTime? LastModDateTime { get; set; }
        public DateTime? AddedDateTime { get; set; }
        public string Asin { get; set; }
        public string ItemName { get; set; }
        public int? QtyRequested { get; set; }
        public string Ponumber { get; set; }

        public virtual CustomerPo CustomerPo { get; set; }
    }
}
