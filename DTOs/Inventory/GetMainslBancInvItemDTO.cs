using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class GetMainslBancInvItemDTO
  {
    [Key]
    public long InventoryItemId { get; set; }
    public int ItemNoId { get; set; }
    public string ItemName { get; set; }
    public int QtyOnHandMainsl { get; set; }
    public int QtyAvailMainsl { get; set; }
    public int QtyOnHandBanc { get; set; }
    public int QtyAvailBanc { get; set; }
    public int QtyOnHandSwcaft { get; set; }
    public int QtyAvailSwcaft { get; set; }
    public int QtyOnHandBasc { get; set; }
    public int QtyAvailBasc { get; set; }
		public int QtyOnHandPrismCast { get; set; }
		public int QtyAvailPrismCast { get; set; }
		public int QtyOnHandPrismCalt { get; set; }
		public int QtyAvailPrismCalt { get; set; }
    public int QtyOnHandZinusTracy { get; set; }
    public int QtyAvailZinusTracy { get; set; }
    public int QtyOnHandZinusChs { get; set; }
    public int QtyAvailZinusChs { get; set; }
    public int StagePOOrigBanc { get; set; }
    public int StagePOOrigBasc { get; set; }
    public int StagePOOrigMainsl { get; set; }
    public int StagePOOrigSwcaft { get; set; }
		public int StagePOOrigPrismCast { get; set; }
		public int StagePOOrigPrismCalt { get; set; }
    public int StagePOOrigZinusTracy { get; set; }
    public int StagePOOrigZinusChs { get; set; }
    public int StagePOOrigBanc60 { get; set; }
    public int StagePOOrigBasc60 { get; set; }
    public int StagePOOrigMainsl60 { get; set; }
    public int StagePOOrigSwcaft60 { get; set; }
		public int StagePOOrigPrismCast60 { get; set; }
		public int StagePOOrigPrismCalt60 { get; set; }
    public int StagePOOrigZinusTracy60 { get; set; }
    public int StagePOOrigZinusChs60 { get; set; }
    public int StagePOOrigBanc90 { get; set; }
    public int StagePOOrigBasc90 { get; set; }
    public int StagePOOrigMainsl90 { get; set; }
    public int StagePOOrigSwcaft90 { get; set; }
		public int StagePOOrigPrismCast90 { get; set; }
		public int StagePOOrigPrismCalt90 { get; set; }
    public int StagePOOrigZinusTracy90 { get; set; }
    public int StagePOOrigZinusChs90 { get; set; }
    public int StagePOModBanc { get; set; }
    public int StagePOModBasc { get; set; }
    public int StagePOModMainsl { get; set; }
    public int StagePOModSwcaft { get; set; }
		public int StagePOModPrismCast { get; set; }
		public int StagePOModPrismCalt { get; set; }
    public int StagePOModZinusTracy { get; set; }
    public int StagePOModZinusChs { get; set; }
    public int InvBANCItemId { get; set; }
    public int InvMainslItemId { get; set; }
    public int InvBASCItemId { get; set; }
    public int InvSwcaftItemId { get; set; }
    public int InvPrismCastItemId { get; set; }
    public int InvPrismCaltItemId { get; set; }
    public int InvZinusTracyItemId { get; set; }
    public int InvZinusChsItemId { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Remark { get; set; }
    public bool isActivatedRemark { get; set; }
    public string NoteRuleRemark { get; set; }
    public string CreatedByRemark { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime LastModifiedTime { get; set; }
    public string LastModifiedBy { get; set; }
    public bool isSet { get; set; }
    public int beforeBOMQtyAvailMainsl { get; set; }
    public int beforeBOMQtyAvailBanc { get; set; }
    public bool isChildSet { get; set; }
    public bool isCooMaster { get; set;}

  }
}
