using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdBolPickWh
    {
        public int PickWhId { get; set; }
        public int ItemNoId { get; set; }
        public int? P1Id { get; set; }
        public int? P2Id { get; set; }
        public int? P3Id { get; set; }
        public int? P4Id { get; set; }
        public int? P5Id { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation P1 { get; set; }
        public virtual BpmLocation P2 { get; set; }
        public virtual BpmLocation P3 { get; set; }
        public virtual BpmLocation P4 { get; set; }
        public virtual BpmLocation P5 { get; set; }
    }
}
