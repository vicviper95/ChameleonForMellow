using System;

namespace Chameleon.DTOs.Inventory
{
  public class ItemABCDTO
  {
    public int? mkid { get; set; }
    public int? itid { get; set; }
    public string locName { get; set; }
    public DateTime invDate { get; set; }
    public decimal invAmt { get; set; }
    public int? invQty { get; set; }
    public char abc { get; set; }
    public char xyz { get; set; }
    public decimal itoBpm { get; set; }
    public decimal itoCG { get; set; }
  }
}
