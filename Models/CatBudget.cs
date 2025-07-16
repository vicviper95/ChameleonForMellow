using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CatBudget
    {
        public int CatBudgetId { get; set; }
        public DateTime FirstDoM { get; set; }
        public int BudgetMkId { get; set; }
        public int? BudgetLocId { get; set; }
        public int? CatZinusId { get; set; }
        public int? QtyPo { get; set; }
        public int? QtyOb { get; set; }
        public int QtyIv { get; set; }
        public int? AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public int? ItemNoId { get; set; }
        public bool? IsSkuLevel { get; set; }
        public int? QtyMs { get; set; }
        public int? QtyBeg { get; set; }
        public int? QtyAdj { get; set; }

        public virtual BudgetLoc BudgetLoc { get; set; }
        public virtual BudgetMk BudgetMk { get; set; }
        public virtual CategoryZinu CatZinus { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
