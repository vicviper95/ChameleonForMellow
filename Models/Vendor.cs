using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            BillAllocationByVendors = new HashSet<BillAllocationByVendor>();
            BillCreditTs = new HashSet<BillCreditT>();
            DrayageFeet = new HashSet<DrayageFoot>();
            FobCostTracks = new HashSet<FobCostTrack>();
            FreightInvoiceTs = new HashSet<FreightInvoiceT>();
            ItemBoxDims = new HashSet<ItemBoxDim>();
            ItemCurrFobs = new HashSet<ItemCurrFob>();
            ItemFobHists = new HashSet<ItemFobHist>();
            ItemFobVcs = new HashSet<ItemFobVc>();
            ItemFvcps = new HashSet<ItemFvcp>();
            ItemMdFobs = new HashSet<ItemMdFob>();
            PoBillTs = new HashSet<PoBillT>();
            PoCmTs = new HashSet<PoCmT>();
            PoTs = new HashSet<PoT>();
            Vend2WhLts = new HashSet<Vend2WhLt>();
            VendorBillTs = new HashSet<VendorBillT>();
        }

        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string SageName { get; set; }
        public int? VendCatId { get; set; }
        public string PrimaryContact { get; set; }
        public string Email { get; set; }
        public string BillAddress { get; set; }
        public string Country { get; set; }
        public string Terms { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModTime { get; set; }
        public string BillAddr1 { get; set; }
        public string BillAddr2 { get; set; }
        public string BillAddr3 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillZip { get; set; }
        public string BillCountry { get; set; }
        public string BillAddressee { get; set; }
        public int? DfPortOrigId { get; set; }
        public int? AvgLeadTime { get; set; }
        public bool IsZinus { get; set; }

        public virtual PortOrigin DfPortOrig { get; set; }
        public virtual VendCategory VendCat { get; set; }
        public virtual ICollection<BillAllocationByVendor> BillAllocationByVendors { get; set; }
        public virtual ICollection<BillCreditT> BillCreditTs { get; set; }
        public virtual ICollection<DrayageFoot> DrayageFeet { get; set; }
        public virtual ICollection<FobCostTrack> FobCostTracks { get; set; }
        public virtual ICollection<FreightInvoiceT> FreightInvoiceTs { get; set; }
        public virtual ICollection<ItemBoxDim> ItemBoxDims { get; set; }
        public virtual ICollection<ItemCurrFob> ItemCurrFobs { get; set; }
        public virtual ICollection<ItemFobHist> ItemFobHists { get; set; }
        public virtual ICollection<ItemFobVc> ItemFobVcs { get; set; }
        public virtual ICollection<ItemFvcp> ItemFvcps { get; set; }
        public virtual ICollection<ItemMdFob> ItemMdFobs { get; set; }
        public virtual ICollection<PoBillT> PoBillTs { get; set; }
        public virtual ICollection<PoCmT> PoCmTs { get; set; }
        public virtual ICollection<PoT> PoTs { get; set; }
        public virtual ICollection<Vend2WhLt> Vend2WhLts { get; set; }
        public virtual ICollection<VendorBillT> VendorBillTs { get; set; }
    }
}
