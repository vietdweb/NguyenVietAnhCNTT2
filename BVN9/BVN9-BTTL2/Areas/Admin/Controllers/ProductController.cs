using BVN9_BTTL2.Data;
using BVN9_BTTL2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BVN9_BTTL2.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController(ApplicationDbContext db) : Controller
{
    public async Task<IActionResult> Index() => View(await db.Products.Include(x => x.Category).OrderByDescending(x => x.Id).ToListAsync());

    private async Task LoadCategories() => ViewBag.Categories = await db.Categories.Where(x => x.Status == 1).OrderBy(x => x.Name).ToListAsync();

    public async Task<IActionResult> Create() { await LoadCategories(); return View(new Product()); }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (await db.Products.AnyAsync(x => x.Name == product.Name)) ModelState.AddModelError(nameof(product.Name), "Tên sản phẩm đã tồn tại.");
        if (!ModelState.IsValid) { await LoadCategories(); return View(product); }
        product.CreatedDate = DateTime.Today;
        db.Products.Add(product);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();
        var product = await db.Products.FindAsync(id);
        if (product is null) return NotFound();
        await LoadCategories();
        return View(product);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.Id) return NotFound();
        if (await db.Products.AnyAsync(x => x.Name == product.Name && x.Id != id)) ModelState.AddModelError(nameof(product.Name), "Tên sản phẩm đã tồn tại.");
        if (!ModelState.IsValid) { await LoadCategories(); return View(product); }
        var existing = await db.Products.FindAsync(id);
        if (existing is null) return NotFound();
        existing.Name = product.Name; existing.Price = product.Price; existing.SalePrice = product.SalePrice;
        existing.Status = product.Status; existing.CategoryId = product.CategoryId; existing.Image = product.Image; existing.Description = product.Description;
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var product = await db.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        return product is null ? NotFound() : View(product);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await db.Products.FindAsync(id);
        if (product is not null) db.Products.Remove(product);
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
