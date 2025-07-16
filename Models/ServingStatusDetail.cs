using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ServingStatusDetail
    {
        public int ServingStatusDetailId { get; set; }
        public string StatusDetailType { get; set; }
        public int ProdCampHistId { get; set; }
        public DateTime AddetTime { get; set; }

        public virtual AmzProductCampHist ProdCampHist { get; set; }
    }
}
