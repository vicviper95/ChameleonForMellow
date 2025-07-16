using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BudgetByLoc
    {
        public int BudgetByLocId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int Qty { get; set; }
    }
}
