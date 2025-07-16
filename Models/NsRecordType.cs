using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsRecordType
    {
        public NsRecordType()
        {
            GlimpactTCreatedFromTypes = new HashSet<GlimpactT>();
            GlimpactTTypes = new HashSet<GlimpactT>();
            NsCreditMemoTs = new HashSet<NsCreditMemoT>();
            NsInvoiceTs = new HashSet<NsInvoiceT>();
            VendorBillTOrderTypes = new HashSet<VendorBillT>();
            VendorBillTTypes = new HashSet<VendorBillT>();
        }

        public int TypeId { get; set; }
        public string NsType { get; set; }
        public string Type { get; set; }

        public virtual ICollection<GlimpactT> GlimpactTCreatedFromTypes { get; set; }
        public virtual ICollection<GlimpactT> GlimpactTTypes { get; set; }
        public virtual ICollection<NsCreditMemoT> NsCreditMemoTs { get; set; }
        public virtual ICollection<NsInvoiceT> NsInvoiceTs { get; set; }
        public virtual ICollection<VendorBillT> VendorBillTOrderTypes { get; set; }
        public virtual ICollection<VendorBillT> VendorBillTTypes { get; set; }
    }
}
