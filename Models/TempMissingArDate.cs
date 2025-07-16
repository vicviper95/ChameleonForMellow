using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TempMissingArDate
    {
        public int? Seq { get; set; }
        public string InvNo { get; set; }
        public string PoNo { get; set; }
        public string ArBat { get; set; }
        public DateTime? ArDate { get; set; }
    }
}
