using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdsB2pIc
    {
        public AdsB2pIc()
        {
            Ads850s = new HashSet<Ads850>();
            Ads860s = new HashSet<Ads860>();
            AdsB2pTs = new HashSet<AdsB2pT>();
        }

        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }
        public byte As2Status { get; set; }

        public virtual ICollection<Ads850> Ads850s { get; set; }
        public virtual ICollection<Ads860> Ads860s { get; set; }
        public virtual ICollection<AdsB2pT> AdsB2pTs { get; set; }
    }
}
