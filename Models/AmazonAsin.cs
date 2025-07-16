using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmazonAsin
    {
        public int AsinId { get; set; }
        public string AmzAsin { get; set; }
        public string CustSku { get; set; }
        public string Title { get; set; }
        public int? ItemNoId { get; set; }
    }
}
