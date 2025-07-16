using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemClass
    {
        public ItemClass()
        {
            FcstItemClasses = new HashSet<FcstItemClass>();
        }

        public byte ItemClassId { get; set; }
        public string ClassName { get; set; }

        public virtual ICollection<FcstItemClass> FcstItemClasses { get; set; }
    }
}
