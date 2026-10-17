using BVN9_BTTL2.Data;
using BVN9_BTTL2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BVN9_BTTL2.Areas.Admin.Controllers;

[Area("Admin")]
public class BannerController(ApplicationDbContext db) : Controller
{
    public async Task<IActionResult> Index() => View(await db.Banners.OrderBy(x => x.Priority).ThenByDescending(x => x.Id).ToListAsync());
    public IActionResult Create() => View(new Banner());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Banner banner)
    {
        if (await db.Banners.AnyAsync(x => x.Name == banner.Name)) ModelState.AddModelError(nameof(banner.Name), "Tên banner đã tồn tại.");
        if (!ModelState.IsValid) return View(banner);
        db.Banners.Add(banner); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id) { if (id is null) return NotFound(); var item = await db.Banners.FindAsync(id); return item is null ? NotFound() : View(item); }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Banner banner)
    {
        if (id != banner.Id) return NotFound();
        if (await db.Banners.AnyAsync(x => x.Name == banner.Name && x.Id != id)) ModelState.AddModelError(nameof(banner.Name), "Tên banner đã tồn tại.");
        if (!ModelState.IsValid) return View(banner);
        db.Update(banner); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id) { if (id is null) return NotFound(); var item = await db.Banners.FindAsync(id); return item is null ? NotFound() : View(item); }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) { var item = await db.Banners.FindAsync(id); if (item is not null) db.Banners.Remove(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
}
