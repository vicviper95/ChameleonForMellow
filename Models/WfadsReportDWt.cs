using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfadsReportDWt
    {
        public WfadsReportDWt()
        {
            WfadsReportDWctHalos = new HashSet<WfadsReportD>();
            WfadsReportDWcts = new HashSet<WfadsReportD>();
            WfadsReportDWvts = new HashSet<WfadsReportD>();
        }

        public int WtId { get; set; }
        public decimal AttributedRetailSales { get; set; }
        public decimal AttributedWholesaleCost { get; set; }
        public decimal AttributedOrders { get; set; }
        public decimal AttributedUnits { get; set; }
        public decimal CostPerAttributedOrder { get; set; }
        public decimal RetailRoas { get; set; }
        public decimal WholesaleCostRoas { get; set; }

        public virtual ICollection<WfadsReportD> WfadsReportDWctHalos { get; set; }
        public virtual ICollection<WfadsReportD> WfadsReportDWcts { get; set; }
        public virtual ICollection<WfadsReportD> WfadsReportDWvts { get; set; }
    }
}
