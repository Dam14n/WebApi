using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/goals")]
	public class GoalsController : ApiController
	{
		private GoalService goalService = new GoalService();

		[Route("")]
		public List<GoalDTO> Get()
		{
			return goalService.GetAll();
		}

		[Route("{id:int}")]
		public GoalDTO Get(int id)
		{
			return goalService.GetGoal(id);
		}

		[Route("~/api/players/{playerId:int}/goals")]
		public List<GoalDTO> GetGoalsByPlayer(int playerId)
		{
			return goalService.GetGoalsByPlayer(playerId);
		}

		[Route("~/api/players/{playerId:int}/goals/{id:int}")]
		public GoalDTO GetGoalByPlayer(int playerId, int id)
		{
			return goalService.GetGoalByPlayer(playerId, id);
		}

		[Route("~/api/matches/{matchId:int}/goals")]
		public List<GoalDTO> GetGoalsByMatch(int matchId)
		{
			return goalService.GetGoalsByMatch(matchId);
		}

		[Route("~/api/matches/{matchId:int}/goals/{id:int}")]
		public GoalDTO GetGoalByMatch(int matchId, int id)
		{
			return goalService.GetGoalByMatch(matchId, id);
		}

		[Route("~/api/matches/{matchId:int}/teams/{teamId}/goals")]
		public List<GoalDTO> GetGoalsByMatchAndTeam(int matchId, int teamId)
		{
			return goalService.GetGoalsByMatchAndTeam(matchId, teamId);
		}

		[Route("~/api/teams/{teamId:int}/goals")]
		public List<GoalDTO> GetGoalsByTeam(int teamId)
		{
			return goalService.GetGoalsByTeam(teamId);
		}

		[Route("~/api/teams/{teamId:int}/goals/{id:int}")]
		public GoalDTO GetGoalByTeam(int teamId, int id)
		{
			return goalService.GetGoalByTeam(teamId, id);
		}

		[Route("create")]
		[HttpPost]
		public IHttpActionResult Create(GoalDTO goalDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			goalService.Create(goalDTO);
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
			goalService.Delete(id);
			return Ok();
		}

		[Route("put")]
		[HttpPut]
		public IHttpActionResult Put(GoalDTO goalDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			goalService.Put(goalDTO);
			return Ok();
		}
	}
}
