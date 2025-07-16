using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WhinvDetailCategory
    {
        public WhinvDetailCategory()
        {
            Whinvoices = new HashSet<Whinvoice>();
        }

        public int WhinvDetailCategoryId { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<Whinvoice> Whinvoices { get; set; }
    }
}
