using BookShop.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            return View(context.GetProducts());
        }
        public IActionResult EnterProduct()
        {
            return View();
        }
        public IActionResult ViewProduct(string ID)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            Product pro = context.ViewProduct(ID);
            ViewData.Model = pro;
            return View();
        }

        public IActionResult AddProduct(Product pro)
        {
            int count;
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            count = context.AddProduct(pro);
            return RedirectToAction("Index", "Product");

        }

        public IActionResult UpdateProduct(Product pro)
        {
            int count;
            string message = string.Empty;
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");

            count = context.UpdateProduct(pro);

            return RedirectToAction("Index", "Product");

        }
        public IActionResult DeleteProduct(string ID)
        {

            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            context.DeleteProduct(ID);
            return RedirectToAction("Index", "Product");
        }
    }
}
