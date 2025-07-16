using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzdroutstandPo
    {
        public int AmzdrOstdId { get; set; }
        public string Amzponumber { get; set; }
        public int? ItemnoId { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public int? OutstandingQty { get; set; }
    }
}
