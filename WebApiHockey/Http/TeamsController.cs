using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
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

		[Route("create")]
		[HttpPost]
		public IHttpActionResult Create(TeamDTO teamDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			teamService.Create(teamDTO);
			return Ok();
		}

		[Route("delete/{id:int}")]
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (id <= 0)
			{
				return BadRequest("Not a valid division id");
			}
			teamService.Delete(id);
			return Ok();
		}

		[Route("put")]
		[HttpPut]
		public IHttpActionResult Put(TeamDTO teamDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			teamService.Put(teamDTO);
			return Ok();
		}
	}
}
