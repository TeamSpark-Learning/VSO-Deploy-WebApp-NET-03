using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MyOnlineShop.Web.Context;
using MyOnlineShop.Web.Models;

namespace MyOnlineShop.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = ConfigurationManager.AppSettings["MySiteTitle"] ?? string.Empty;

			var model = new CategoryListModel();

			using (var context = new MyOnlineShopContext())
			{
				model.Categories = context
					.Categories
					.Include(i => i.Goods)
					.ToList();
			}

			return View(model);
		}
	}
}