using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoPossibleSalesOrder
    {
        public int PossCustSoId { get; set; }
        public int Year { get; set; }
        public int WkNum { get; set; }
        public string Customer { get; set; }
        public string ItemNo { get; set; }
        public int Qty { get; set; }

        public virtual KoMarketPlace CustomerNavigation { get; set; }
        public virtual KoItemno ItemNoNavigation { get; set; }
    }
}
