using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Inventory
{
  public class GetAvailableInventoryNotesDTO
  {
    public int NotesRulesId { get; set; }
    public Boolean isActivated { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedTime { get; set; }
    public string LastModifiedBy { get; set; }
    public string LastModifiedTime { get; set; }
    public string RemarkCategory { get; set; }
    public string NoteRule { get; set; }
    public int NoteCategory { get; set; }
  }
}
