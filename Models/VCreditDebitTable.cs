using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VCreditDebitTable
    {
        public string Adjtype { get; set; }
        public DateTime? Invdate { get; set; }
        public decimal Retdate { get; set; }
        public string Crdnumber { get; set; }
        public string Invnumber { get; set; }
        public string Ordnumber { get; set; }
        public string Customer { get; set; }
        public string Ponumber { get; set; }
        public string Location { get; set; }
        public string Desc { get; set; }
        public string Item { get; set; }
        public decimal? Qtyrt { get; set; }
        public decimal? Cdamt { get; set; }
    }
}
