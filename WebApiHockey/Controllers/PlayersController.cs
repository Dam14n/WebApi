using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	[RoutePrefix("api/players")]
	public class PlayersController : ApiController
	{
		private PlayerService PlayerService = new PlayerService();

		[Route("")]
		public List<PlayerDTO> Get()
		{
			return PlayerService.GetAll();
		}

		[Route("{id:int}")]
		public PlayerDTO Get(int id)
		{
			return PlayerService.GetPlayer(id);
		}
	}
}
