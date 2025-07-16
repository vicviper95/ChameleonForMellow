using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BudgetDetail
    {
        public int BudgetId { get; set; }
        public DateTime FirstDoM { get; set; }
        public int BudgetMkId { get; set; }
        public int? CatZinusId { get; set; }
        public decimal? Amount { get; set; }
        public int? Quantity { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public int LastModBy { get; set; }
        public DateTime LastModDate { get; set; }
        public int? Cat3Id { get; set; }
        public bool IsNewness { get; set; }

        public virtual BudgetMk BudgetMk { get; set; }
        public virtual CategoryZinu CatZinus { get; set; }
    }
}
