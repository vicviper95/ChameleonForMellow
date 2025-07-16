using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemStatusHistory
    {
        public int ItemStatusHistoryId { get; set; }
        public int ItemNoId { get; set; }
        public int? LastItemStatusId { get; set; }
        public int? NewItemStatusId { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
