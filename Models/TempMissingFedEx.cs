using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TempMissingFedEx
    {
        public int? Seq { get; set; }
        public string PoNo { get; set; }
        public string SkuP { get; set; }
        public int? QtyP { get; set; }
        public string SkiC { get; set; }
        public string TrkNo { get; set; }
        public double? FedNet { get; set; }
        public string TrkNo2 { get; set; }
    }
}
