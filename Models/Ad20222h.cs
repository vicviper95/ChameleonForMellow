using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ad20222h
    {
        public int AdItemId { get; set; }
        public int ItemNoId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
