using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CycleCountZhw
    {
        public int CycleCountId { get; set; }
        public int LocationId { get; set; }
        public string ZoneId { get; set; }
        public byte RowId { get; set; }
        public byte? ColId { get; set; }
        public string PosId { get; set; }
        public string LevId { get; set; }
        public int ItemNoId { get; set; }
        public int Qty { get; set; }
        public DateTime TimeUpdated { get; set; }
        public string Note { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual KoLocation Location { get; set; }
    }
}
