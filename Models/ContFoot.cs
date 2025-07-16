using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ContFoot
    {
        public ContFoot()
        {
            ContFeeDs = new HashSet<ContFeeD>();
        }

        public int ContFeeTId { get; set; }
        public decimal? Volume { get; set; }
        public int? Packages { get; set; }
        public int BolFeeTId { get; set; }
        public string ContainerNo { get; set; }
        public string SizeType { get; set; }

        public virtual BolFoot BolFeeT { get; set; }
        public virtual ICollection<ContFeeD> ContFeeDs { get; set; }
    }
}
