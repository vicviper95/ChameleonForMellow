using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsRemit
    {
        public NsRemit()
        {
            CmRemits = new HashSet<CmRemit>();
            InvRemits = new HashSet<InvRemit>();
            NsInvRemits = new HashSet<NsInvRemit>();
            NsRemitDeducts = new HashSet<NsRemitDeduct>();
        }

        public int RemitId { get; set; }
        public string RemitNo { get; set; }
        public DateTime RemitDate { get; set; }
        public decimal RemitTotal { get; set; }
        public int MarketPlaceId { get; set; }
        public int IsProcessed { get; set; }
        public string Note { get; set; }
        public int? IsImported { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? ModifiedByWho { get; set; }
        public int? AddedEmp { get; set; }

        public virtual KoMarketPlace MarketPlace { get; set; }
        public virtual ICollection<CmRemit> CmRemits { get; set; }
        public virtual ICollection<InvRemit> InvRemits { get; set; }
        public virtual ICollection<NsInvRemit> NsInvRemits { get; set; }
        public virtual ICollection<NsRemitDeduct> NsRemitDeducts { get; set; }
    }
}
