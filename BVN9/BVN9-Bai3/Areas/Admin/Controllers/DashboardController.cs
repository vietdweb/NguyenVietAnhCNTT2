using Microsoft.AspNetCore.Mvc;

namespace BVN9_Bai3.Areas.Admins.Controllers
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