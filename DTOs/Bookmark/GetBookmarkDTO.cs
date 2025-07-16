using System.ComponentModel.DataAnnotations;

namespace Chameleon.DTOs.Bookmark
{
  public class GetBookmarkDTO
  {
    [Key]
    public int BookmarkId { get; set; }
    public int Dept_Employee_Id { get; set; }
    public bool isDept { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
  }
}
