using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CategoryZinu
    {
        public CategoryZinu()
        {
            BpmItemCatZinOlds = new HashSet<BpmItem>();
            BpmItemCatZinus = new HashSet<BpmItem>();
            BudgetDetails = new HashSet<BudgetDetail>();
            CatBudgets = new HashSet<CatBudget>();
            KoItemnos = new HashSet<KoItemno>();
        }

        public int CatZinusId { get; set; }
        public string CatZinus { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BpmItem> BpmItemCatZinOlds { get; set; }
        public virtual ICollection<BpmItem> BpmItemCatZinus { get; set; }
        public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
        public virtual ICollection<CatBudget> CatBudgets { get; set; }
        public virtual ICollection<KoItemno> KoItemnos { get; set; }
    }
}
