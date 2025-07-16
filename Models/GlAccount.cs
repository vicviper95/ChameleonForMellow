using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class GlAccount
    {
        public GlAccount()
        {
            AdInvValuationGls = new HashSet<AdInvValuationGl>();
            BillActivities = new HashSet<BillActivity>();
            BillCreditDs = new HashSet<BillCreditD>();
            CmOrigins = new HashSet<CmOrigin>();
            CrdDs = new HashSet<CrdD>();
            FreightInvoiceLines = new HashSet<FreightInvoiceLine>();
            GlimpactDs = new HashSet<GlimpactD>();
            InvWorksheetDs = new HashSet<InvWorksheetD>();
            JournalDs = new HashSet<JournalD>();
            NsCreditMemoDs = new HashSet<NsCreditMemoD>();
            NsCreditMemoTs = new HashSet<NsCreditMemoT>();
            NsExpenseCategories = new HashSet<NsExpenseCategory>();
            NsInvoiceDs = new HashSet<NsInvoiceD>();
            NsInvoiceTs = new HashSet<NsInvoiceT>();
            PoBillDs = new HashSet<PoBillD>();
            PoRcvTs = new HashSet<PoRcvT>();
            RemitMatchClaims = new HashSet<RemitMatchClaim>();
            VendorBillDs = new HashSet<VendorBillD>();
            VendorBillTs = new HashSet<VendorBillT>();
        }

        public int AccountId { get; set; }
        public int NsIntId { get; set; }
        public string AccountNo { get; set; }
        public string Account { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool? IsSummary { get; set; }
        public int? ItemNoId { get; set; }
        public string Name { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual ICollection<AdInvValuationGl> AdInvValuationGls { get; set; }
        public virtual ICollection<BillActivity> BillActivities { get; set; }
        public virtual ICollection<BillCreditD> BillCreditDs { get; set; }
        public virtual ICollection<CmOrigin> CmOrigins { get; set; }
        public virtual ICollection<CrdD> CrdDs { get; set; }
        public virtual ICollection<FreightInvoiceLine> FreightInvoiceLines { get; set; }
        public virtual ICollection<GlimpactD> GlimpactDs { get; set; }
        public virtual ICollection<InvWorksheetD> InvWorksheetDs { get; set; }
        public virtual ICollection<JournalD> JournalDs { get; set; }
        public virtual ICollection<NsCreditMemoD> NsCreditMemoDs { get; set; }
        public virtual ICollection<NsCreditMemoT> NsCreditMemoTs { get; set; }
        public virtual ICollection<NsExpenseCategory> NsExpenseCategories { get; set; }
        public virtual ICollection<NsInvoiceD> NsInvoiceDs { get; set; }
        public virtual ICollection<NsInvoiceT> NsInvoiceTs { get; set; }
        public virtual ICollection<PoBillD> PoBillDs { get; set; }
        public virtual ICollection<PoRcvT> PoRcvTs { get; set; }
        public virtual ICollection<RemitMatchClaim> RemitMatchClaims { get; set; }
        public virtual ICollection<VendorBillD> VendorBillDs { get; set; }
        public virtual ICollection<VendorBillT> VendorBillTs { get; set; }
    }
}
