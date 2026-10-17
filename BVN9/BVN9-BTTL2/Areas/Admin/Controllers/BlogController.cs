using BVN9_BTTL2.Data;
using BVN9_BTTL2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BVN9_BTTL2.Areas.Admin.Controllers;

[Area("Admin")]
public class BlogController(ApplicationDbContext db) : Controller
{
    public async Task<IActionResult> Index() => View(await db.Blogs.OrderByDescending(x => x.Id).ToListAsync());
    public IActionResult Create() => View(new Blog());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Blog blog)
    {
        if (await db.Blogs.AnyAsync(x => x.Name == blog.Name)) ModelState.AddModelError(nameof(blog.Name), "Tên bài viết đã tồn tại.");
        if (!ModelState.IsValid) return View(blog);
        blog.CreatedDate = DateTime.Today; db.Blogs.Add(blog); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id) { if (id is null) return NotFound(); var item = await db.Blogs.FindAsync(id); return item is null ? NotFound() : View(item); }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Blog blog)
    {
        if (id != blog.Id) return NotFound();
        if (await db.Blogs.AnyAsync(x => x.Name == blog.Name && x.Id != id)) ModelState.AddModelError(nameof(blog.Name), "Tên bài viết đã tồn tại.");
        if (!ModelState.IsValid) return View(blog);
        db.Update(blog); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id) { if (id is null) return NotFound(); var item = await db.Blogs.FindAsync(id); return item is null ? NotFound() : View(item); }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) { var item = await db.Blogs.FindAsync(id); if (item is not null) db.Blogs.Remove(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
}
