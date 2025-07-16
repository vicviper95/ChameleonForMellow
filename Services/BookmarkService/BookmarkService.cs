using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chameleon.DTOs.Bookmark;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Chameleon.Services.BookmarkService
{
  public class BookmarkService : IBookmarkService
  {
    public Task<ServiceResponse<List<GetBookmarkDTO>>> AddBookmark(AddBookmarkDTO newBookmark)
    {
      throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<GetBookmarkDTO>>> DeleteBookmark(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<GetBookmarkDTO>>> GetAllBookmarks()
    {
      throw new NotImplementedException();
    }

    public Task<ServiceResponse<GetBookmarkDTO>> GetBookmarkById(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ServiceResponse<GetBookmarkDTO>> UpdateBookmark(UpdateBookmarkDTO updateBookmark)
    {
      throw new NotImplementedException();
    }
  }
}
