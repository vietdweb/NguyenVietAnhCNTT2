using Microsoft.AspNetCore.Mvc;
using BVN4_BBTL.Models;

namespace BVN4_BBTL.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 4,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/product.jpg",
                    Price = 2500000
                },
                new Product
                {
                    Id = 5,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/product.jpg",
                    Price = 2500000
                },
                new Product
                {
                    Id = 6,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/product.jpg",
                    Price = 2500000
                }
            };

            return View(products);
        }
    }
}