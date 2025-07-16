using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsDeductType
    {
        public NsDeductType()
        {
            NsRemitDeducts = new HashSet<NsRemitDeduct>();
        }

        public int DeductTypeId { get; set; }
        public string DeductName { get; set; }
        public decimal? DeductPercent { get; set; }
        public int? MarketPlaceId { get; set; }
        public DateTime? StartDate { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<NsRemitDeduct> NsRemitDeducts { get; set; }
    }
}
