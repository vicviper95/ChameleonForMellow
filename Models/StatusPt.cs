using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class StatusPt
    {
        public StatusPt()
        {
            PickTasks = new HashSet<PickTask>();
            SodPts = new HashSet<SodPt>();
        }

        public int PtStatusId { get; set; }
        public string PtStatus { get; set; }
        public int? NsTaskId { get; set; }
        public int? NsLineId { get; set; }

        public virtual ICollection<PickTask> PickTasks { get; set; }
        public virtual ICollection<SodPt> SodPts { get; set; }
    }
}
