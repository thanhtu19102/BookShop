using BookShop.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            return View(context.GetOrders());
        }
        public IActionResult ViewOrder(string Id)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            return View(context.ViewOrder(Id));
        }
    }
}
