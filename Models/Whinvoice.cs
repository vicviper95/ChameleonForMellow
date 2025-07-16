using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Whinvoice
    {
        public int WhinvoiceId { get; set; }
        public string VendorMain { get; set; }
        public int? VendorMainId { get; set; }
        public string Whlocation { get; set; }
        public int? WhlocId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? Gldate { get; set; }
        public DateTime? InvoiceMonth { get; set; }
        public int? WhinvDescrCategoryId { get; set; }
        public int? WhinvDetailCategoryId { get; set; }
        public decimal? Amount { get; set; }

        public virtual WhinvDescrCategory WhinvDescrCategory { get; set; }
        public virtual WhinvDetailCategory WhinvDetailCategory { get; set; }
    }
}
