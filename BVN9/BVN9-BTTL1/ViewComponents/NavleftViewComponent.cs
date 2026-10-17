using Microsoft.AspNetCore.Mvc;

namespace BVN9_BTTL1.ViewComponents
{
    [ViewComponent(Name = "NavLeft")]
    public class NavleftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
