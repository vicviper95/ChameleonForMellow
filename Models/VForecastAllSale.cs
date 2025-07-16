using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VForecastAllSale
    {
        public decimal Invuniq { get; set; }
        public DateTime? Invdate { get; set; }
        public int? MarketPlaceId { get; set; }
        public string Customer { get; set; }
        public int? LocationId { get; set; }
        public string Loc { get; set; }
        public byte? IsKitting { get; set; }
        public int? ItemnoId { get; set; }
        public string Item { get; set; }
        public decimal? Qty { get; set; }
    }
}
