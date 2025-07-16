using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemDutyTarif
    {
        public int DutyTarifId { get; set; }
        public int ItemNoId { get; set; }
        public decimal Duty { get; set; }
        public decimal Tariff { get; set; }
        public DateTime DateFr { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
