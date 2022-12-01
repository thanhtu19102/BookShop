﻿using Microsoft.AspNetCore.Mvc;

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
    }
}
