using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdPallet
    {
        public AdPallet()
        {
            AdSsccs = new HashSet<AdSscc>();
        }

        public int PalletId { get; set; }
        public string Name { get; set; }
        public int ArnId { get; set; }
        public int? SsccId { get; set; }

        public virtual AdArn Arn { get; set; }
        public virtual AdSscc Sscc { get; set; }
        public virtual ICollection<AdSscc> AdSsccs { get; set; }
    }
}
