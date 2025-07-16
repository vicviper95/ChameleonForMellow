using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CmStatus
    {
        public CmStatus()
        {
            CmTs = new HashSet<CmT>();
            NsCreditMemoTs = new HashSet<NsCreditMemoT>();
        }

        public int CmStatusId { get; set; }
        public string Status { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<CmT> CmTs { get; set; }
        public virtual ICollection<NsCreditMemoT> NsCreditMemoTs { get; set; }
    }
}
