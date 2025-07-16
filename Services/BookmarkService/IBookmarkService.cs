using System.Collections.Generic;
using System.Threading.Tasks;
using Chameleon.DTOs.Bookmark;
using Chameleon.Models;

namespace Chameleon.Services.BookmarkService
{
  public interface IBookmarkService
  {
    Task<ServiceResponse<List<GetBookmarkDTO>>> GetAllBookmarks();
    Task<ServiceResponse<GetBookmarkDTO>> GetBookmarkById(int id);
    Task<ServiceResponse<List<GetBookmarkDTO>>> AddBookmark(AddBookmarkDTO newBookmark);
    Task<ServiceResponse<GetBookmarkDTO>> UpdateBookmark(UpdateBookmarkDTO updateBookmark);
    Task<ServiceResponse<List<GetBookmarkDTO>>> DeleteBookmark(int id);
  }
}
