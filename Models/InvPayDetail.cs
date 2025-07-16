using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvPayDetail
    {
        public int InvPayDetailId { get; set; }
        public int ItemNoId { get; set; }
        public decimal? Rate { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int InvPayId { get; set; }
    }
}
