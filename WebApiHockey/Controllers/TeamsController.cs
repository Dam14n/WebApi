using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	[RoutePrefix("api/teams")]
	public class TeamsController : ApiController
	{
		private TeamService teamService = new TeamService();

		[Route("")]
		public List<TeamDTO> Get()
		{
			return teamService.GetAll();
		}

		[Route("{id:int}")]
		public TeamDTO Get(int id)
		{
			return teamService.GetTeam(id);
		}

		[Route("~/api/matches/{matchId:int}/teams")]
		public List<TeamDTO> GetTeamsByMatch(int matchId)
		{
			return teamService.GetTeamsByMatch(matchId);
		}

		[Route("~/api/matches/{matchId:int}/teams/{id:int}")]
		public TeamDTO GetTeamByMatch(int matchId, int id)
		{
			return teamService.GetTeamByMatch(matchId, id);
		}
	}
}
