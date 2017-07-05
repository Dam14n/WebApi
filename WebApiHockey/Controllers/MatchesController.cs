using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	[RoutePrefix("api/matches")]
	public class MatchesController : ApiController
	{
		private MatchService MatchService = new MatchService();

		[Route("")]
		public List<MatchDTO> Get()
		{
			return MatchService.GetAll();
		}

		[Route("{id:int}")]
		public MatchDTO Get(int id)
		{
			return MatchService.GetMatch(id);
		}
	}
}
