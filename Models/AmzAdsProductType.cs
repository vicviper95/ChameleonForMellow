using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzAdsProductType
    {
        public AmzAdsProductType()
        {
            AmzAdsRptCreateHistories = new HashSet<AmzAdsRptCreateHistory>();
        }

        public int ProductTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AmzAdsRptCreateHistory> AmzAdsRptCreateHistories { get; set; }
    }
}
