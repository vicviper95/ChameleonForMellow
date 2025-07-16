using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SodPt
    {
        public int SodPtId { get; set; }
        public int SoDId { get; set; }
        public int NsPtNo { get; set; }
        public int NsPtLineId { get; set; }
        public int? NsPtCompId { get; set; }
        public int? PickBinId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyToPick { get; set; }
        public decimal QtyPicked { get; set; }
        public int PtStatusId { get; set; }
        public DateTime? SoDate { get; set; }
        public DateTime TimePlanned { get; set; }
        public DateTime? LastModTime { get; set; }
        public int? NsPickTxId { get; set; }
        public string ToteNo { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual PickTask NsPtNoNavigation { get; set; }
        public virtual MslBinNo PickBin { get; set; }
        public virtual StatusPt PtStatus { get; set; }
        public virtual SoD SoD { get; set; }
    }
}
