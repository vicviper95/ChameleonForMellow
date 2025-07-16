using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzAdsRefreshToken
    {
        public int Id { get; set; }
        public string Scope { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ModfiedTime { get; set; }
    }
}
