using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BudgetType
    {
        public BudgetType()
        {
            AmzProductCampHists = new HashSet<AmzProductCampHist>();
        }

        public int BudgetTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzProductCampHist> AmzProductCampHists { get; set; }
    }
}
