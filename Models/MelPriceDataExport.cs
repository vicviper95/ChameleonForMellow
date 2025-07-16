using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MelPriceDataExport
    {
        public string CstmNm { get; set; }
        public string Date { get; set; }
        public string Sku { get; set; }
        public string ItemId { get; set; }
        public string RtlPrice { get; set; }
        public string ProductDescription { get; set; }
        public string NewCategory { get; set; }
        public string Category { get; set; }
        public string Collection { get; set; }
        public string Link { get; set; }
    }
}
