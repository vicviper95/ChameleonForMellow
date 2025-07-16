using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SpRecapOcf
    {
        public int SpRecapOcfId { get; set; }
        public int CountryFrId { get; set; }
        public int CountryToId { get; set; }
        public decimal OceanCost { get; set; }
        public DateTime DateFr { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Country CountryFr { get; set; }
        public virtual Country CountryTo { get; set; }
    }
}
