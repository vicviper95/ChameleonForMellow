using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TakeBacker
    {
        public TakeBacker()
        {
            TakeBacks = new HashSet<TakeBack>();
            TbAreas = new HashSet<TbArea>();
            TbCosts = new HashSet<TbCost>();
        }

        public int TakeBackerId { get; set; }
        public string TbName { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModTime { get; set; }
        public int Priority { get; set; }

        public virtual ICollection<TakeBack> TakeBacks { get; set; }
        public virtual ICollection<TbArea> TbAreas { get; set; }
        public virtual ICollection<TbCost> TbCosts { get; set; }
    }
}
