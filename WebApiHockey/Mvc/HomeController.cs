using System.Web.Mvc;

namespace WebApiHockey.Mvc
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}
