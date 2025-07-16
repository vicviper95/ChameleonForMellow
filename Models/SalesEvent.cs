using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SalesEvent
    {
        public SalesEvent()
        {
            SalesEventDetails = new HashSet<SalesEventDetail>();
        }

        public int SalesEventId { get; set; }
        public int MarketPlaceId { get; set; }
        public string SalesEventName { get; set; }
        public string EventId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Store { get; set; }
        public DateTime? LastModDateTime { get; set; }
        public DateTime? AddedDateTime { get; set; }

        public virtual KoMarketPlace MarketPlace { get; set; }
        public virtual ICollection<SalesEventDetail> SalesEventDetails { get; set; }
    }
}
