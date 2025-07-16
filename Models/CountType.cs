using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CountType
    {
        public CountType()
        {
            InvtCntTs = new HashSet<InvtCntT>();
        }

        public int CountTypeId { get; set; }
        public string CountType1 { get; set; }

        public virtual ICollection<InvtCntT> InvtCntTs { get; set; }
    }
}
