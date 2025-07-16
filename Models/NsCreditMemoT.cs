using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsCreditMemoT
    {
        public NsCreditMemoT()
        {
            NsApplieds = new HashSet<NsApplied>();
            NsCreditMemoDs = new HashSet<NsCreditMemoD>();
            NsCrediteds = new HashSet<NsCredited>();
        }

        public int NsCreditMemoTId { get; set; }
        public int NsIntId { get; set; }
        public int TypeId { get; set; }
        public string DocNo { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public int StatusId { get; set; }
        public int? CreatedFromId { get; set; }
        public int GlaccountId { get; set; }
        public string Remittance { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }

        public virtual NsInvoiceT CreatedFrom { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual GlAccount Glaccount { get; set; }
        public virtual CmStatus Status { get; set; }
        public virtual NsRecordType Type { get; set; }
        public virtual ICollection<NsApplied> NsApplieds { get; set; }
        public virtual ICollection<NsCreditMemoD> NsCreditMemoDs { get; set; }
        public virtual ICollection<NsCredited> NsCrediteds { get; set; }
    }
}
