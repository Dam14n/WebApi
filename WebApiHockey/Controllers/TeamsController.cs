using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	[RoutePrefix("api/teams")]
	public class TeamsController : ApiController
	{
		private TeamService TeamService = new TeamService();

		[Route("")]
		public List<TeamDTO> Get()
		{
			return TeamService.GetAll();
		}

		[Route("{id:int}")]
		public TeamDTO Get(int id)
		{
			return TeamService.GetTeam(id);
		}
	}
}
