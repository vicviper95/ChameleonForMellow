using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SodBol
    {
        public int SodBolId { get; set; }
        public int SoDId { get; set; }
        public int BolId { get; set; }
        public int ItemNoId { get; set; }
        public int PalletTypeId { get; set; }
        public decimal ActPalQty { get; set; }
        public decimal? StdPalQty { get; set; }
        public decimal VolumeCf { get; set; }
        public decimal WeightLb { get; set; }
        public int QtyOrdered { get; set; }
        public int QtyPicked { get; set; }
        public int QtyShipped { get; set; }
        public int QtyInvoiced { get; set; }
        public DateTime SoDate { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? LastModTime { get; set; }
        public string BolNo { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public int? NsSyncFail { get; set; }

        public virtual AdBol Bol { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual PalletType PalletType { get; set; }
        public virtual SoD SoD { get; set; }
    }
}
