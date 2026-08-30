using Microsoft.AspNetCore.Mvc;
using NvaLessson3.Models;

namespace NvaLessson3.Controllers
{
    public class ProductController : Controller
    {
        [Route("san-pham", Name = "Product")]
        public IActionResult Index()
        {
            ViewBag.Categories = GetCategories();
            ViewBag.Products = GetProducts();
            return View();
        }

        [Route("san-pham/danh-muc/{categoryId}")]
        public IActionResult Category(int categoryId)
        {
            ViewBag.Categories = GetCategories();
            ViewBag.Products = GetProducts()
                .Where(product => product.CategoryId == categoryId)
                .ToList();
            ViewBag.SelectedCategoryId = categoryId;
            return View("Index");
        }

        [Route("san-pham/chi-tiet/{id}")]
        public IActionResult Detail(string id)
        {
            Product product = GetProducts().FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Quần áo" },
                new Category { Id = 2, Name = "Túi xách" },
                new Category { Id = 3, Name = "Đồng hồ" },
                new Category { Id = 4, Name = "Ti vi" },
                new Category { Id = 5, Name = "Tủ lạnh" },
                new Category { Id = 6, Name = "Máy bơm" }
            };
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = "1", Name = "Bộ đồ bơi cho trẻ em nam", Image = "/Avatar/1.jpg", Price = 500000, SalePrice = 350000, CategoryId = 1, Description = "Bộ đồ bơi dành cho trẻ em nam", Status = true, CreatedAt = DateTime.Now },
                new Product { Id = "2", Name = "Bộ đồ bơi cho trẻ em nữ", Image = "/Avatar/2.jpg", Price = 500000, SalePrice = 350000, CategoryId = 1, Description = "Bộ đồ bơi dành cho trẻ em nữ", Status = true, CreatedAt = DateTime.Now },
                new Product { Id = "3", Name = "Bộ đồ bơi cho trẻ em", Image = "/Avatar/3.jpg", Price = 500000, SalePrice = 350000, CategoryId = 1, Description = "Bộ đồ bơi trẻ em", Status = true, CreatedAt = DateTime.Now },
                new Product { Id = "4", Name = "Bộ đồ bơi cho trẻ em thời trang", Image = "/Avatar/4.jpg", Price = 500000, SalePrice = 350000, CategoryId = 1, Description = "Bộ đồ bơi thời trang", Status = true, CreatedAt = DateTime.Now },
                new Product { Id = "5", Name = "Túi thời trang mẫu mới 2021", Image = "/Avatar/5.jpg", Price = 500000, SalePrice = 350000, CategoryId = 2, Description = "Túi thời trang nữ", Status = true, CreatedAt = DateTime.Now },
                new Product { Id = "6", Name = "Túi thời trang da cá sấu", Image = "/Avatar/6.jpg", Price = 500000, SalePrice = 350000, CategoryId = 2, Description = "Túi da thời trang", Status = true, CreatedAt = DateTime.Now }
            };
        }
    }
}