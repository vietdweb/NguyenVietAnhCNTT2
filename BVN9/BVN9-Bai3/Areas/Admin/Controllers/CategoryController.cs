using Microsoft.AspNetCore.Mvc;

namespace BVN9_Bai3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
