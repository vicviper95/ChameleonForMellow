using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdBol
    {
        public AdBol()
        {
            AdArns = new HashSet<AdArn>();
            AdBolChanges = new HashSet<AdBolChange>();
            SodBols = new HashSet<SodBol>();
        }

        public int BolId { get; set; }
        public int? NsBolId { get; set; }
        public string BolNo { get; set; }
        public int ShipFrWhId { get; set; }
        public int ShipToAfcId { get; set; }
        public decimal TotalActPallet { get; set; }
        public decimal? TotalStdPallet { get; set; }
        public int TotalCarton { get; set; }
        public decimal? TotalVolumeCf { get; set; }
        public decimal? TotalWeightLb { get; set; }
        public DateTime DateBolCreated { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime ExpShipDate { get; set; }
        public string PoNo { get; set; }
        public int IsClosed { get; set; }
        public DateTime? TimeStaged { get; set; }
        public DateTime? TimeRouteReqd { get; set; }

        public virtual BpmLocation ShipFrWh { get; set; }
        public virtual AdAfcid ShipToAfc { get; set; }
        public virtual ICollection<AdArn> AdArns { get; set; }
        public virtual ICollection<AdBolChange> AdBolChanges { get; set; }
        public virtual ICollection<SodBol> SodBols { get; set; }
    }
}
