using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SpRecapRo
    {
        public int SpRecapRosId { get; set; }
        public DateTime DateFr { get; set; }
        public DateTime? DateTo { get; set; }
        public int RosChannelId { get; set; }
        public decimal RosPercent { get; set; }

        public virtual SpRecapChn RosChannel { get; set; }
    }
}
