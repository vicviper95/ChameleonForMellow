using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MatInfu
    {
        public MatInfu()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int MatInfusId { get; set; }
        public string InfusName { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
