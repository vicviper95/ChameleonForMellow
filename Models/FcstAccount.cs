using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstAccount
    {
        public FcstAccount()
        {
            FcstWkDs = new HashSet<FcstWkD>();
            FcstWkHts = new HashSet<FcstWkHt>();
        }

        public int FcstAccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<FcstWkD> FcstWkDs { get; set; }
        public virtual ICollection<FcstWkHt> FcstWkHts { get; set; }
    }
}
