using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BpmBol
    {
        public int BolId { get; set; }
        public string ProNo { get; set; }
        public int OrderId { get; set; }
        public string Scac { get; set; }

        public virtual Order Order { get; set; }
    }
}
