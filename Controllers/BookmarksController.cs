using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chameleon.Models;

namespace Chameleon.Controllers
{
    public class BookmarksController : Controller
    {
        private readonly KOALAContext _context;

        public BookmarksController(KOALAContext context)
        {
            _context = context;
        }

        // GET: Bookmarks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookmarks.ToListAsync());
        }

        // GET: Bookmarks/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookmark = await _context.Bookmarks
                .FirstOrDefaultAsync(m => m.BookmarkId == id);
            if (bookmark == null)
            {
                return NotFound();
            }

            return View(bookmark);
        }

        // GET: Bookmarks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookmarkId,DeptEmployeeId,IsDept,Link,Description")] Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookmark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookmark);
        }

        // GET: Bookmarks/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookmark = await _context.Bookmarks.FindAsync(id);
            if (bookmark == null)
            {
                return NotFound();
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BookmarkId,DeptEmployeeId,IsDept,Link,Description")] Bookmark bookmark)
        {
            if (id != bookmark.BookmarkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookmark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookmarkExists(bookmark.BookmarkId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookmark);
        }

        // GET: Bookmarks/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookmark = await _context.Bookmarks
                .FirstOrDefaultAsync(m => m.BookmarkId == id);
            if (bookmark == null)
            {
                return NotFound();
            }

            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var bookmark = await _context.Bookmarks.FindAsync(id);
            _context.Bookmarks.Remove(bookmark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookmarkExists(long id)
        {
            return _context.Bookmarks.Any(e => e.BookmarkId == id);
        }
    }
}
