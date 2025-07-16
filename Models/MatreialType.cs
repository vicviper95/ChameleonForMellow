using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MatreialType
    {
        public MatreialType()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int MaterialTypeId { get; set; }
        public string MaterialName { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
