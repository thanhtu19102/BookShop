using Microsoft.AspNetCore.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewProduct()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
