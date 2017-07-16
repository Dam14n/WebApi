using System.Web.Mvc;

namespace WebApiHockey.Mvc
{
	public class ApiController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}
