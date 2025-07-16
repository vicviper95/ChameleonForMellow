using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObRptT
    {
        public AmzObRptT()
        {
            AmzObForecastings = new HashSet<AmzObForecasting>();
            AmzObInvs = new HashSet<AmzObInv>();
            AmzObNetPpms = new HashSet<AmzObNetPpm>();
            AmzObSales = new HashSet<AmzObSale>();
            AmzObTraffics = new HashSet<AmzObTraffic>();
        }

        public int RptId { get; set; }
        public DateTime DateStart { get; set; }
        public int? AddedUserId { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LasetModTime { get; set; }
        public int? TimeFameId { get; set; }
        public int? DistributorId { get; set; }
        public int? ProgramId { get; set; }
        public DateTime? DateEnd { get; set; }

        public virtual AmzDistributor Distributor { get; set; }
        public virtual AmzProgram Program { get; set; }
        public virtual TimeFrame TimeFame { get; set; }
        public virtual ICollection<AmzObForecasting> AmzObForecastings { get; set; }
        public virtual ICollection<AmzObInv> AmzObInvs { get; set; }
        public virtual ICollection<AmzObNetPpm> AmzObNetPpms { get; set; }
        public virtual ICollection<AmzObSale> AmzObSales { get; set; }
        public virtual ICollection<AmzObTraffic> AmzObTraffics { get; set; }
    }
}
