using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemPromoPrice
    {
        public int ItemPromoPriceId { get; set; }
        public int CustomerId { get; set; }
        public int ItemNoId { get; set; }
        public decimal PromoPrice { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
