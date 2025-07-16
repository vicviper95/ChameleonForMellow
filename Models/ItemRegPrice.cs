using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemRegPrice
    {
        public int RegPriceId { get; set; }
        public int CustomerId { get; set; }
        public int ItemNoId { get; set; }
        public decimal RegularPrice { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string VendorCode { get; set; }
        public DateTime? ConfirmDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
