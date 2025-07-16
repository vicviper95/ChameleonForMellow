using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Country
    {
        public Country()
        {
            Customs = new HashSet<Custom>();
            InvtCoOs = new HashSet<InvtCoO>();
            ItemCurrFobCountryFrs = new HashSet<ItemCurrFob>();
            ItemCurrFobCountryTos = new HashSet<ItemCurrFob>();
            ItemFobHistCountryFrs = new HashSet<ItemFobHist>();
            ItemFobHistCountryTos = new HashSet<ItemFobHist>();
            ItemMdFobCountryFrs = new HashSet<ItemMdFob>();
            ItemMdFobCountryTos = new HashSet<ItemMdFob>();
            KoAmzsellerRankHistories = new HashSet<KoAmzsellerRankHistory>();
            PoTs = new HashSet<PoT>();
            SpRecapDutyCountryFrs = new HashSet<SpRecapDuty>();
            SpRecapDutyCountryTos = new HashSet<SpRecapDuty>();
            SpRecapOcfCountryFrs = new HashSet<SpRecapOcf>();
            SpRecapOcfCountryTos = new HashSet<SpRecapOcf>();
            SpcInvDs = new HashSet<SpcInvD>();
        }

        public int CountryId { get; set; }
        public string FullName { get; set; }
        public string Alpha2 { get; set; }
        public string Alpha3 { get; set; }
        public int? NsIntId { get; set; }
        public string NsCode { get; set; }

        public virtual ICollection<Custom> Customs { get; set; }
        public virtual ICollection<InvtCoO> InvtCoOs { get; set; }
        public virtual ICollection<ItemCurrFob> ItemCurrFobCountryFrs { get; set; }
        public virtual ICollection<ItemCurrFob> ItemCurrFobCountryTos { get; set; }
        public virtual ICollection<ItemFobHist> ItemFobHistCountryFrs { get; set; }
        public virtual ICollection<ItemFobHist> ItemFobHistCountryTos { get; set; }
        public virtual ICollection<ItemMdFob> ItemMdFobCountryFrs { get; set; }
        public virtual ICollection<ItemMdFob> ItemMdFobCountryTos { get; set; }
        public virtual ICollection<KoAmzsellerRankHistory> KoAmzsellerRankHistories { get; set; }
        public virtual ICollection<PoT> PoTs { get; set; }
        public virtual ICollection<SpRecapDuty> SpRecapDutyCountryFrs { get; set; }
        public virtual ICollection<SpRecapDuty> SpRecapDutyCountryTos { get; set; }
        public virtual ICollection<SpRecapOcf> SpRecapOcfCountryFrs { get; set; }
        public virtual ICollection<SpRecapOcf> SpRecapOcfCountryTos { get; set; }
        public virtual ICollection<SpcInvD> SpcInvDs { get; set; }
    }
}
