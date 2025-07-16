using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PickTask
    {
        public PickTask()
        {
            SodPts = new HashSet<SodPt>();
        }

        public int NsPtNo { get; set; }
        public int PickPlanId { get; set; }
        public int Priority { get; set; }
        public int? StagingBinId { get; set; }
        public string ToteNo { get; set; }
        public int? EmpAsgnedId { get; set; }
        public int? EmpPickedId { get; set; }
        public DateTime TimePlanned { get; set; }
        public DateTime? TimeCompleted { get; set; }
        public int PtStatusId { get; set; }

        public virtual Employee EmpAsgned { get; set; }
        public virtual Employee EmpPicked { get; set; }
        public virtual PickPlan PickPlan { get; set; }
        public virtual StatusPt PtStatus { get; set; }
        public virtual MslBinNo StagingBin { get; set; }
        public virtual ICollection<SodPt> SodPts { get; set; }
    }
}
