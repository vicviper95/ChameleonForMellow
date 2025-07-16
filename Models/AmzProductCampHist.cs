using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzProductCampHist
    {
        public AmzProductCampHist()
        {
            ServingStatusDetails = new HashSet<ServingStatusDetail>();
        }

        public int ProdCampHistId { get; set; }
        public long ProdCampId { get; set; }
        public int? StrategyId { get; set; }
        public int CampStateId { get; set; }
        public int TargetingTypeId { get; set; }
        public decimal Budget { get; set; }
        public int BudgetTypeId { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        public int ServingStatusId { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual BudgetType BudgetType { get; set; }
        public virtual CampStateType CampState { get; set; }
        public virtual AmzProductCampaign ProdCamp { get; set; }
        public virtual ServingStatusType ServingStatus { get; set; }
        public virtual StrategyType Strategy { get; set; }
        public virtual TargetingType TargetingType { get; set; }
        public virtual ICollection<ServingStatusDetail> ServingStatusDetails { get; set; }
    }
}
