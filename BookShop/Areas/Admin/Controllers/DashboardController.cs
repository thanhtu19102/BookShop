using BookShop.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area ("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Check(User us)
        { 
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
           int count = context.CheckLogin(us.username, us.password);
            if (count > 0)
            {
                return RedirectToAction("Index","Dashboard");
            }
            else
                return RedirectToAction("Login", "Dashboard");
           
        }

    
    }
}
