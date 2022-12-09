using BookShop.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            return View(context.GetCategorys());
        }
        public IActionResult EnterCategory()
        {
            return View();
        }
        public IActionResult AddCategory(Category cat)
        {
            int count;
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            count = context.AddCategory(cat);
            return RedirectToAction("Index", "Category");

        }

        public IActionResult ViewCategory(string Id)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            Category cat = context.ViewCategory(Id);
            ViewData.Model = cat;
            return View();
        }

        public IActionResult UpdateCategory(Category cat)
        {
            
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");

            context.UpdateCategory(cat);

            return RedirectToAction("Index", "Category");
        }

        public IActionResult DeleteCategory(string ID)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            context.DeleteCategory(ID);
            return RedirectToAction("Index", "Category");
        }
    }
}
