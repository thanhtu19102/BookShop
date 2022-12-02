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
        public IActionResult EnterUser()
        {
            return View();

        }

        public IActionResult ViewUser(string Id)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            User us = context.ViewUser(Id);
            ViewData.Model = us;
            return View();
        }
        //public IActionResult UpdateUser(User us)
        //{
        //    int count;
        //    StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
        //    count = context.UpdateUser(us);
        //    if (count > 0)
        //        ViewData["thongbao"] = "Update thành công";
        //    else
        //        ViewData["thongbao"] = "Update không thành công";
        //    return View();

        //}
        public IActionResult DeleteUser(string ID)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            int count = context.DeleteUser(ID);
            if (count > 0)
                ViewData["thongbao"] = "Xóa thành công";
            else
                ViewData["thongbao"] = "Xóa không thành công";
            return RedirectToAction("Index", "User");
        }

    }
}
