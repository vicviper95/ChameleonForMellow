using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemTrkCoO
    {
        public int ItemTrkCoOId { get; set; }
        public int ItemNoId { get; set; }
        public int CoItemNoId { get; set; }
        public string CountryCode { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual BpmItem CoItemNo { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
