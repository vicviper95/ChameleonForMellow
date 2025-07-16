using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class StatusIf
    {
        public StatusIf()
        {
            ItemFfts = new HashSet<ItemFft>();
            ToFfts = new HashSet<ToFft>();
        }

        public int IfStatusId { get; set; }
        public string IfStatus { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<ItemFft> ItemFfts { get; set; }
        public virtual ICollection<ToFft> ToFfts { get; set; }
    }
}
