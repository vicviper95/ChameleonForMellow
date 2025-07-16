using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BillCategory
    {
        public BillCategory()
        {
            BillActivities = new HashSet<BillActivity>();
        }

        public int BillCategoryId { get; set; }
        public string Category { get; set; }

        public virtual ICollection<BillActivity> BillActivities { get; set; }
    }
}
