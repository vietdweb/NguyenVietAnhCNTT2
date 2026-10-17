using Microsoft.AspNetCore.Mvc;

namespace BVN9_BTTL1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
