using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class ComparedInvFeedsDTO
  {
    public string bpmSku { get; set; }
    public string ItemStatus { get; set; }
    public int ItemNoId { get; set; }
    public string Description { get; set; }
    public int totalQty { get; set; }
    public string custSku { get; set; }
    public int manualFeedsQty { get; set; }
    public int chameleonFeedsQty { get; set; }
    public string etc { get; set; }
    public string appliedRule { get; set; }

    // For Wayfair
    public int totalQtyBanc { get; set; }
    public int totalQtyMainsl { get; set; }
    public int totalQtySWCAFT { get; set; }
    public int manualFeedsQtyBanc { get; set; }
    public int manualFeedsQtyMainsl { get; set; }
    public int manualFeedsQtySWCAFT { get; set; }
    public int chameleonFeedsQtyBanc { get; set; }
    public int chameleonFeedsQtyMainsl { get; set; }
    public int chameleonFeedsQtySWCAFT { get; set; }
    public string appliedRuleBanc { get; set; }
    public string appliedRuleMainsl { get; set; }
    public string appliedRuleSWCAFT { get; set; }

    // Added for HomeDepot
    public int totalQtyBasc { get; set; }
    public int manualFeedsQtyBasc { get; set; }
    public int chameleonFeedsQtyBasc { get; set; }
    public string appliedRuleBasc { get; set; }
  }
}
