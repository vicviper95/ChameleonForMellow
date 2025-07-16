using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObFcstD
    {
        public int FcstDId { get; set; }
        public int FcstId { get; set; }
        public int WkNo { get; set; }
        public DateTime FcstDate { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public int FcstUnit { get; set; }

        public virtual AmzObForecasting Fcst { get; set; }
    }
}
