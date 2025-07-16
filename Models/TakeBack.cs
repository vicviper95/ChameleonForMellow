using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TakeBack
    {
        public TakeBack()
        {
            TbDetails = new HashSet<TbDetail>();
        }

        public int TakeBackId { get; set; }
        public int? TakeBackerId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime PickWdStart { get; set; }
        public DateTime PickWdEnd { get; set; }
        public decimal? TotalCostEst { get; set; }
        public DateTime LastModKoT { get; set; }
        public int LastModKoE { get; set; }
        public string TbAppNo { get; set; }
        public string TbInvNo { get; set; }
        public decimal? TotalCostAct { get; set; }
        public int TbStatusId { get; set; }
        public DateTime? DateToPick { get; set; }
        public DateTime? DatePicked { get; set; }
        public int SoDId { get; set; }
        public int TbItemId { get; set; }
        public int TbQty { get; set; }
        public decimal? TbCostEst { get; set; }
        public decimal? TbCostAct { get; set; }

        public virtual SoD SoD { get; set; }
        public virtual TakeBacker TakeBacker { get; set; }
        public virtual TbItem TbItem { get; set; }
        public virtual TbStatus TbStatus { get; set; }
        public virtual ICollection<TbDetail> TbDetails { get; set; }
    }
}
