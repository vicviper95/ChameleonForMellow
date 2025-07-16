using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CatBudgetWk
    {
        public int CatBudgetWkId { get; set; }
        public DateTime SundayOfWk { get; set; }
        public int BudgetMkId { get; set; }
        public int? BudgetLocId { get; set; }
        public int? CatZinusId { get; set; }
        public int? ItemNoId { get; set; }
        public int? QtyPo { get; set; }
        public int? QtyObFcst { get; set; }
        public int? QtyOb { get; set; }
        public int QtyIv { get; set; }
        public int? AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsSkuLevel { get; set; }
    }
}
