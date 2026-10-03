using BVN7_BTTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BVN7_BTTL.Controllers
{
    public class ProductController : Controller
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Điện thoại" },
            new Category { Id = 2, Name = "Laptop" },
            new Category { Id = 3, Name = "Phụ kiện" }
        };

        private static List<Product> products = new List<Product>();

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(
                categories,
                "Id",
                "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            Product product,
            IFormFile imageFile)
        {
            if (imageFile == null)
            {
                ModelState.AddModelError(
                    "Image",
                    "Vui lòng chọn hình ảnh");
            }

            if (product.SalePrice != product.Price * 0.9f)
            {
                ModelState.AddModelError(
                    "SalePrice",
                    "Giá khuyến mãi phải giảm đúng 10%");
            }

            if (product.Description.Contains(
                "die",
                StringComparison.OrdinalIgnoreCase)
                || product.Description.Contains(
                "admin",
                StringComparison.OrdinalIgnoreCase)
                || product.Description.Contains(
                "fuck",
                StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError(
                    "Description",
                    "Mô tả không được chứa từ nhạy cảm");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.CategoryId = new SelectList(
                    categories,
                    "Id",
                    "Name",
                    product.CategoryId);

                return View(product);
            }

            product.Id = products.Count + 1;

            product.Image = SaveImage(imageFile);

            products.Add(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.CategoryId = new SelectList(
                categories,
                "Id",
                "Name",
                product.CategoryId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            int id,
            Product product,
            IFormFile imageFile)
        {
            Product oldProduct = products.FirstOrDefault(p => p.Id == id);

            if (oldProduct == null)
            {
                return NotFound();
            }

            if (product.SalePrice != product.Price * 0.9f)
            {
                ModelState.AddModelError(
                    "SalePrice",
                    "Giá khuyến mãi phải giảm đúng 10%");
            }

            if (product.Description.Contains(
                "die",
                StringComparison.OrdinalIgnoreCase)
                || product.Description.Contains(
                "admin",
                StringComparison.OrdinalIgnoreCase)
                || product.Description.Contains(
                "fuck",
                StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError(
                    "Description",
                    "Mô tả không được chứa từ nhạy cảm");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.CategoryId = new SelectList(
                    categories,
                    "Id",
                    "Name",
                    product.CategoryId);

                return View(product);
            }

            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.SalePrice = product.SalePrice;
            oldProduct.Description = product.Description;
            oldProduct.CategoryId = product.CategoryId;

            if (imageFile != null)
            {
                oldProduct.Image = SaveImage(imageFile);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);
            }

            return RedirectToAction("Index");
        }

        private string SaveImage(IFormFile imageFile)
        {
            string folder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "products");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string fileName = Guid.NewGuid().ToString()
                + Path.GetExtension(imageFile.FileName);

            string filePath = Path.Combine(folder, fileName);

            FileStream fileStream = new FileStream(
                filePath,
                FileMode.Create);

            imageFile.CopyTo(fileStream);

            fileStream.Close();

            return fileName;
        }
    }
}