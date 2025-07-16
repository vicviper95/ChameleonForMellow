using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CatGlobalZ
    {
        public CatGlobalZ()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int CatGlobalZId { get; set; }
        public string CatGlobal { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
