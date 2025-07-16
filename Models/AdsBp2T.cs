using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdsBp2T
    {
        public AdsBp2T()
        {
            Ads855s = new HashSet<Ads855>();
            Ads856s = new HashSet<Ads856>();
            Ads865s = new HashSet<Ads865>();
        }

        public int EdiTsId { get; set; }
        public int EdiIcId { get; set; }

        public virtual AdsB2pIc EdiIc { get; set; }
        public virtual ICollection<Ads855> Ads855s { get; set; }
        public virtual ICollection<Ads856> Ads856s { get; set; }
        public virtual ICollection<Ads865> Ads865s { get; set; }
    }
}
