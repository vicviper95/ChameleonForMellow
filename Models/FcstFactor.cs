using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstFactor
    {
        public int FcstFactorId { get; set; }
        public DateTime CalendaDate { get; set; }
        public string SeasonName { get; set; }
        public decimal SeasonFactor { get; set; }
        public decimal? GrowthFactor { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModDate { get; set; }
    }
}
