using System.Web.Http;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/boards")]
	public class BoardsController : ApiController
	{
		private BoardService boardService = new BoardService();

		[Route("addpositions")]
		[HttpPost]
		public void Positions()
		{
			boardService.AddPositions();
		}
	}
}
