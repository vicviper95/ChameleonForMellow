using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemFft
    {
        public ItemFft()
        {
            EdiTs = new HashSet<EdiT>();
            ItemFfds = new HashSet<ItemFfd>();
        }

        public int IftId { get; set; }
        public int? NsIntId { get; set; }
        public string IfNo { get; set; }
        public DateTime AddedDate { get; set; }
        public string ProNo { get; set; }
        public int? IsNsProed { get; set; }
        public int IfStatusId { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? SoTId { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public string TplShipId { get; set; }
        public bool? IsCreateFailed { get; set; }
        public string Source { get; set; }
        public DateTime? Date { get; set; }
        public int? GlimpactTId { get; set; }
        public bool? IsValid { get; set; }

        public virtual GlimpactT GlimpactT { get; set; }
        public virtual StatusIf IfStatus { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<ItemFfd> ItemFfds { get; set; }
    }
}
