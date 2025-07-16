using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WhinvDescrCategory
    {
        public WhinvDescrCategory()
        {
            Whinvoices = new HashSet<Whinvoice>();
        }

        public int WhinvDescrCategoryId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Whinvoice> Whinvoices { get; set; }
    }
}
