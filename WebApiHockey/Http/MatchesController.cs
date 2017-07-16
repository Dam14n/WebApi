using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/matches")]
	public class MatchesController : ApiController
	{
		private MatchService matchService = new MatchService();

		[Route("")]
		public List<MatchDTO> Get()
		{
			return matchService.GetAll();
		}

		[Route("{id:int}")]
		public MatchDTO Get(int id)
		{
			return matchService.GetMatch(id);
		}

		[Route("~/api/dates/{dateId:int}/matches")]
		public List<MatchDTO> GetDatesByCategory(int dateId)
		{
			return matchService.GetMatchesByDate(dateId);
		}

		[Route("~/api/dates/{dateId:int}/matches/{id:int}")]
		public MatchDTO GetDateByCategory(int dateId, int id)
		{
			return matchService.GetMatchByDate(dateId, id);
		}
	}
}
