using BookShop.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class AccountController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }



        public IActionResult LoginUser()
        {
            return View();
        }

        

        public IActionResult CheckNotLogin()
        {
            ViewData["thongbao"] = "Bạn chưa đăng nhập, hãy đăng nhập để tiếp tụcc!";
            return View();
        }

        public IActionResult RegisterUser(User acc)
        {
            int count;

            //StoreContext context = HttpContext.RequestServices.GetService(typeof(BookShop.Areas.Admin.Models.StoreContext)) as StoreContext;
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            count = context.RegisterUser(acc);
            if (count > 0)
                ViewData["thongbao"] = "Đăng ký Thành Công";

            else
                ViewData["thongbao"] = "Đăng ký không thành công";
            return View();
        }



        public IActionResult CheckRegister()
        {
            return View();
        }

        public IActionResult CheckRegisterError(User us)
        {
            int count;
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            count = context.CheckRegisterError(us.username, us.email);
            if (count > 0)
                ViewData["thongbao"] = "Tai khoan da ton tai";
            else
            { return View(RegisterUser(us)); }
            return View();
        }

        public IActionResult CheckLoginUser(User us)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            int count = context.CheckLoginUser(us.username, us.password);

            if (count == 0)
            {
                return RedirectToAction("LoginUser", "User");
            }

            if (count > 0)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();

        }

        public IActionResult ShopForUser(User us)
        {
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            return View(context.GetProducts());
        }

       
    }
}
