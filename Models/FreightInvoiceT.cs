using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FreightInvoiceT
    {
        public FreightInvoiceT()
        {
            FreightInvoiceDs = new HashSet<FreightInvoiceD>();
        }

        public int FreightInvoiceTId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public int VendorId { get; set; }
        public decimal? AmountPer { get; set; }
        public int? VendorBillId { get; set; }
        public int? VendorBillCreditId { get; set; }
        public bool IsBillCredit { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual PoBillT VendorBill { get; set; }
        public virtual BillCreditT VendorBillCredit { get; set; }
        public virtual ICollection<FreightInvoiceD> FreightInvoiceDs { get; set; }
    }
}
