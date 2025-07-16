using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MatType
    {
        public MatType()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int MatTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
