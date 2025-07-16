using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RmaDetail
    {
        public RmaDetail()
        {
            WmsRmaDetails = new HashSet<WmsRmaDetail>();
        }

        public int RmaLineId { get; set; }
        public int RmaId { get; set; }
        public int ItemShippedId { get; set; }
        public int RmaQtyApproved { get; set; }
        public decimal? AmountShipDeduct { get; set; }
        public decimal? AmountRefund { get; set; }
        public int ItemReplacedId { get; set; }
        public int? RmaQtyReturned { get; set; }
        public int? RmaQtyReplaced { get; set; }
        public DateTime? TimeReturned { get; set; }

        public virtual KoItemno ItemReplaced { get; set; }
        public virtual KoItemno ItemShipped { get; set; }
        public virtual Rma Rma { get; set; }
        public virtual ICollection<WmsRmaDetail> WmsRmaDetails { get; set; }
    }
}
