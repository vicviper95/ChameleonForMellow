using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiSeko945Error
    {
        public int EdiSeko945ErrorId { get; set; }
        public int? OrderLineId { get; set; }
        public int? ItemnoId { get; set; }
        public int? QtyOrdered { get; set; }
        public int? QtyShipped { get; set; }
        public int? QtyDiff { get; set; }
        public int? Seko945Id { get; set; }

        public virtual KoItemno Itemno { get; set; }
        public virtual OrderDetail OrderLine { get; set; }
        public virtual EdiSeko945 Seko945 { get; set; }
    }
}
