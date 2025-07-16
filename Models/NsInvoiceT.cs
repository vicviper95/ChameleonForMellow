using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsInvoiceT
    {
        public NsInvoiceT()
        {
            NsApplieds = new HashSet<NsApplied>();
            NsCreditMemoTs = new HashSet<NsCreditMemoT>();
            NsCrediteds = new HashSet<NsCredited>();
            NsInvoiceDs = new HashSet<NsInvoiceD>();
        }

        public int NsInvoiceTId { get; set; }
        public int NsIntId { get; set; }
        public int TypeId { get; set; }
        public string DocNo { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DueDate { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountRemaining { get; set; }
        public string Memo { get; set; }
        public int StatusId { get; set; }
        public int? CreatedFromId { get; set; }
        public int GlaccountId { get; set; }
        public string Remittance { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }

        public virtual SoT CreatedFrom { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual GlAccount Glaccount { get; set; }
        public virtual InvStatus Status { get; set; }
        public virtual NsRecordType Type { get; set; }
        public virtual ICollection<NsApplied> NsApplieds { get; set; }
        public virtual ICollection<NsCreditMemoT> NsCreditMemoTs { get; set; }
        public virtual ICollection<NsCredited> NsCrediteds { get; set; }
        public virtual ICollection<NsInvoiceD> NsInvoiceDs { get; set; }
    }
}
