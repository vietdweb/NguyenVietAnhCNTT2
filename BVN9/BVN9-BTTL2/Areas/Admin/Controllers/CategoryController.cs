using BVN9_BTTL2.Data;
using BVN9_BTTL2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BVN9_BTTL2.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(ApplicationDbContext db) : Controller
{
    public async Task<IActionResult> Index() => View(await db.Categories.OrderByDescending(x => x.Id).ToListAsync());

    public IActionResult Create() => View(new Category());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if (await db.Categories.AnyAsync(x => x.Name == category.Name))
            ModelState.AddModelError(nameof(category.Name), "Tên danh mục đã tồn tại.");
        if (!ModelState.IsValid) return View(category);
        category.CreatedDate = DateTime.Today;
        db.Categories.Add(category);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();
        var category = await db.Categories.FindAsync(id);
        return category is null ? NotFound() : View(category);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Category category)
    {
        if (id != category.Id) return NotFound();
        if (await db.Categories.AnyAsync(x => x.Name == category.Name && x.Id != id))
            ModelState.AddModelError(nameof(category.Name), "Tên danh mục đã tồn tại.");
        if (!ModelState.IsValid) return View(category);
        db.Update(category);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var category = await db.Categories.FindAsync(id);
        return category is null ? NotFound() : View(category);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (await db.Products.AnyAsync(x => x.CategoryId == id))
        {
            TempData["Error"] = "Không thể xóa danh mục đang có sản phẩm.";
            return RedirectToAction(nameof(Index));
        }
        var category = await db.Categories.FindAsync(id);
        if (category is not null) db.Categories.Remove(category);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
