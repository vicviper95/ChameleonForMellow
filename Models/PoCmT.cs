using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoCmT
    {
        public PoCmT()
        {
            PoCmDs = new HashSet<PoCmD>();
        }

        public int PoCmTId { get; set; }
        public int? Account { get; set; }
        public int? VendorId { get; set; }
        public string PoNo { get; set; }
        public string DocFrom { get; set; }
        public string CmNo { get; set; }
        public DateTime CmDate { get; set; }
        public decimal CmTotal { get; set; }
        public int? CmStatusId { get; set; }
        public string MemoMain { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<PoCmD> PoCmDs { get; set; }
    }
}
