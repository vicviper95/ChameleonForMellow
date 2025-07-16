using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemPriceLevel
    {
        public ItemPriceLevel()
        {
            SoDs = new HashSet<SoD>();
        }

        public int PriceLevelId { get; set; }
        public string Name { get; set; }
        public int? NsIntId { get; set; }
        public bool IsInactive { get; set; }

        public virtual ICollection<SoD> SoDs { get; set; }
    }
}
