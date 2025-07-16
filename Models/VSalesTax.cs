using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VSalesTax
    {
        public DateTime? Invdate { get; set; }
        public string Invnumber { get; set; }
        public string Ordnumber { get; set; }
        public string Customer { get; set; }
        public string Ponumber { get; set; }
        public string Loc { get; set; }
        public string Desc { get; set; }
        public decimal? Sales { get; set; }
    }
}
