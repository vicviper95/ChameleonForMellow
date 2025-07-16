using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VTransfer
    {
        public decimal Audtdate { get; set; }
        public string Itemno { get; set; }
        public string Fromloc { get; set; }
        public string Toloc { get; set; }
        public decimal Quantity { get; set; }
    }
}
