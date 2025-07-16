using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemProductType
    {
        public int ItemProductTypeId { get; set; }
        public string ReportType { get; set; }
        public int ItemNoId { get; set; }
        public string Type { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
