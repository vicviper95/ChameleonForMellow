using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VendorBillT
    {
        public VendorBillT()
        {
            InverseCreatedBill = new HashSet<VendorBillT>();
            VendorBillDs = new HashSet<VendorBillD>();
        }

        public int VendorBillTId { get; set; }
        public int? NsIntId { get; set; }
        public string ExternalId { get; set; }
        public DateTime Date { get; set; }
        public string InvNo { get; set; }
        public int TypeId { get; set; }
        public int VendorId { get; set; }
        public DateTime? DueDate { get; set; }
        public int? CurrencyId { get; set; }
        public double? ExchangeRate { get; set; }
        public int? AccountId { get; set; }
        public decimal Amount { get; set; }
        public int? OrderTypeId { get; set; }
        public bool IsOnlyKoala { get; set; }
        public string Memo { get; set; }
        public int? CreatedBillId { get; set; }
        public int? AddedEmployeeId { get; set; }
        public DateTime AddedTime { get; set; }
        public string Source { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual Employee AddedEmployee { get; set; }
        public virtual VendorBillT CreatedBill { get; set; }
        public virtual NsCurrency Currency { get; set; }
        public virtual NsRecordType OrderType { get; set; }
        public virtual NsRecordType Type { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<VendorBillT> InverseCreatedBill { get; set; }
        public virtual ICollection<VendorBillD> VendorBillDs { get; set; }
    }
}
