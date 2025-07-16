using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class GlimpactT
    {
        public GlimpactT()
        {
            CmTs = new HashSet<CmT>();
            GlimpactDs = new HashSet<GlimpactD>();
            InvAdjTs = new HashSet<InvAdjT>();
            InvTrTs = new HashSet<InvTrT>();
            InvTs = new HashSet<InvT>();
            ItemFfts = new HashSet<ItemFft>();
            PoRcvTs = new HashSet<PoRcvT>();
            ToFfts = new HashSet<ToFft>();
            ToRcvTs = new HashSet<ToRcvT>();
        }

        public int GlimpactTId { get; set; }
        public int NsIntId { get; set; }
        public int TypeId { get; set; }
        public DateTime Date { get; set; }
        public string DocNo { get; set; }
        public int? CustomerId { get; set; }
        public int? CreatedFromTypeId { get; set; }
        public int? CreatedFromNsIntId { get; set; }

        public virtual NsRecordType CreatedFromType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual NsRecordType Type { get; set; }
        public virtual ICollection<CmT> CmTs { get; set; }
        public virtual ICollection<GlimpactD> GlimpactDs { get; set; }
        public virtual ICollection<InvAdjT> InvAdjTs { get; set; }
        public virtual ICollection<InvTrT> InvTrTs { get; set; }
        public virtual ICollection<InvT> InvTs { get; set; }
        public virtual ICollection<ItemFft> ItemFfts { get; set; }
        public virtual ICollection<PoRcvT> PoRcvTs { get; set; }
        public virtual ICollection<ToFft> ToFfts { get; set; }
        public virtual ICollection<ToRcvT> ToRcvTs { get; set; }
    }
}
