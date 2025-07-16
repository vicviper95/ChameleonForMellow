using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CmT
    {
        public CmT()
        {
            CmDs = new HashSet<CmD>();
        }

        public int CmTId { get; set; }
        public int? NsIntId { get; set; }
        public string CmNo { get; set; }
        public DateTime CmDate { get; set; }
        public decimal CmTotal { get; set; }
        public int CmStatusId { get; set; }
        public string MemoMain { get; set; }
        public DateTime AddedDate { get; set; }
        public string PoNo { get; set; }
        public int? CustomerId { get; set; }
        public string DocFrom { get; set; }
        public int? Account { get; set; }
        public int? SoTId { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public int? GlimpactTId { get; set; }

        public virtual CmStatus CmStatus { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual GlimpactT GlimpactT { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual ICollection<CmD> CmDs { get; set; }
    }
}
