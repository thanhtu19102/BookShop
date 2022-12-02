using BookShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookShop.Models;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            return View(context.GetUsers());
        }

        public IActionResult Login(string username, string password)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            int count = context.CheckLogin(username, password);
            if (count > 0)
                return RedirectToAction("/Admin/Dashboard/Index");
            else
                return RedirectToAction("/Admin/Dashboard/Login");
        
        }
        

    }
}
