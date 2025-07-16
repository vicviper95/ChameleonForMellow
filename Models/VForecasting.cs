using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VForecasting
    {
        public string Itemno { get; set; }
        public string Location { get; set; }
        public int Qty { get; set; }
        public DateTime DateFuture { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
