using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/players")]
	public class PlayersController : ApiController
	{
		private PlayerService playerService = new PlayerService();

		[Route("")]
		public List<PlayerDTO> Get()
		{
			return playerService.GetAll();
		}

		[Route("{id:int}")]
		public PlayerDTO Get(int id)
		{
			return playerService.GetPlayer(id);
		}

		[Route("~/api/teams/{teamId:int}/players")]
		public List<PlayerDTO> GetPlayersByTeam(int teamId)
		{
			return playerService.GetPlayersByTeam(teamId);
		}

		[Route("~/api/teams/{teamId:int}/players/{id:int}")]
		public PlayerDTO GetPlayerByTeam(int teamId, int id)
		{
			return playerService.GetPlayerByTeam(teamId, id);
		}
	}
}
