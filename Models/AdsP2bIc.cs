using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdsP2bIc
    {
        public AdsP2bIc()
        {
            Ads846s = new HashSet<Ads846>();
            Ads850s = new HashSet<Ads850>();
            Ads855s = new HashSet<Ads855>();
            Ads856s = new HashSet<Ads856>();
            Ads860s = new HashSet<Ads860>();
            Ads865s = new HashSet<Ads865>();
        }

        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }

        public virtual ICollection<Ads846> Ads846s { get; set; }
        public virtual ICollection<Ads850> Ads850s { get; set; }
        public virtual ICollection<Ads855> Ads855s { get; set; }
        public virtual ICollection<Ads856> Ads856s { get; set; }
        public virtual ICollection<Ads860> Ads860s { get; set; }
        public virtual ICollection<Ads865> Ads865s { get; set; }
    }
}
