using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VAmzobByComponent
    {
        public DateTime? Date { get; set; }
        public string Customer { get; set; }
        public string Itemno { get; set; }
        public int? QtyAtAmz { get; set; }
        public int? Unitshipped { get; set; }
        public int? Amzobqty { get; set; }
        public int? Openqty { get; set; }
    }
}
