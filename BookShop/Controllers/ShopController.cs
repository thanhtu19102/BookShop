using Microsoft.AspNetCore.Mvc;
using BookShop.Models;
namespace BookShop.Controllers
{
	public class ShopController : Controller
	{
		public IActionResult Index()
		{
            StoreContext context = new StoreContext("server=127.0.0.1;user id=root;password=;port=3306;database=bookshop;");
            return View(context.GetProducts());
		}

	}
}
