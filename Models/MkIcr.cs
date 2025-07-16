using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MkIcr
    {
        public MkIcr()
        {
            AmazonAdRepDetails = new HashSet<AmazonAdRepDetail>();
            AmazonBsrs = new HashSet<AmazonBsr>();
            AmzObForecastings = new HashSet<AmzObForecasting>();
            AmzObInvs = new HashSet<AmzObInv>();
            AmzObNetPpms = new HashSet<AmzObNetPpm>();
            AmzObRealTimeHourlies = new HashSet<AmzObRealTimeHourly>();
            AmzObSales = new HashSet<AmzObSale>();
            AmzObTraffics = new HashSet<AmzObTraffic>();
            AmzObmthlyRptManufInvDs = new HashSet<AmzObmthlyRptManufInvD>();
            AmzObmthlyRptManufSalesDs = new HashSet<AmzObmthlyRptManufSalesD>();
            AmzObmthlyRptNetppmDs = new HashSet<AmzObmthlyRptNetppmD>();
            AvcWkRptDs = new HashSet<AvcWkRptD>();
            AvcWkRptPs = new HashSet<AvcWkRptP>();
            CsInvtFeedDs = new HashSet<CsInvtFeedD>();
            MkInvFeedDs = new HashSet<MkInvFeedD>();
            WayfPpids = new HashSet<WayfPpid>();
            WayfairDeductions = new HashSet<WayfairDeduction>();
            WfsInventories = new HashSet<WfsInventory>();
            WfsInvtLogs = new HashSet<WfsInvtLog>();
            WyfrPricCstStckRepDetails = new HashSet<WyfrPricCstStckRepDetail>();
        }

        public int IcrId { get; set; }
        public int MarketId { get; set; }
        public int ItemNoId { get; set; }
        public string CustSku { get; set; }
        public string CustUpc { get; set; }
        public string CustAsin { get; set; }
        public DateTime? LaunchDate { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsInvFeed { get; set; }
        public bool? IsDisco { get; set; }
        public DateTime? DiscoDate { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? LastModKoT { get; set; }
        public int? LastModKoE { get; set; }
        public DateTime? LastFdsUdate { get; set; }
        public int? LastFdsUby { get; set; }
        public DateTime? ReLaunchDate { get; set; }
        public int? ItemStatusId { get; set; }
        public string MarketUrl { get; set; }
        public int? AmazonCollectionId { get; set; }
        public int? RealTimeId { get; set; }
        public bool IsBypassCooMaster { get; set; }
        public bool? WayfairCgstockRule { get; set; }

        public virtual AmazonCollection AmazonCollection { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual ItemStatus ItemStatus { get; set; }
        public virtual Market Market { get; set; }
        public virtual ICollection<AmazonAdRepDetail> AmazonAdRepDetails { get; set; }
        public virtual ICollection<AmazonBsr> AmazonBsrs { get; set; }
        public virtual ICollection<AmzObForecasting> AmzObForecastings { get; set; }
        public virtual ICollection<AmzObInv> AmzObInvs { get; set; }
        public virtual ICollection<AmzObNetPpm> AmzObNetPpms { get; set; }
        public virtual ICollection<AmzObRealTimeHourly> AmzObRealTimeHourlies { get; set; }
        public virtual ICollection<AmzObSale> AmzObSales { get; set; }
        public virtual ICollection<AmzObTraffic> AmzObTraffics { get; set; }
        public virtual ICollection<AmzObmthlyRptManufInvD> AmzObmthlyRptManufInvDs { get; set; }
        public virtual ICollection<AmzObmthlyRptManufSalesD> AmzObmthlyRptManufSalesDs { get; set; }
        public virtual ICollection<AmzObmthlyRptNetppmD> AmzObmthlyRptNetppmDs { get; set; }
        public virtual ICollection<AvcWkRptD> AvcWkRptDs { get; set; }
        public virtual ICollection<AvcWkRptP> AvcWkRptPs { get; set; }
        public virtual ICollection<CsInvtFeedD> CsInvtFeedDs { get; set; }
        public virtual ICollection<MkInvFeedD> MkInvFeedDs { get; set; }
        public virtual ICollection<WayfPpid> WayfPpids { get; set; }
        public virtual ICollection<WayfairDeduction> WayfairDeductions { get; set; }
        public virtual ICollection<WfsInventory> WfsInventories { get; set; }
        public virtual ICollection<WfsInvtLog> WfsInvtLogs { get; set; }
        public virtual ICollection<WyfrPricCstStckRepDetail> WyfrPricCstStckRepDetails { get; set; }
    }
}
