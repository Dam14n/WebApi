using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class TeamsController : ApiController
	{
		private TeamService TeamService = new TeamService();

		// GET api/values
		public List<TeamDTO> Get()
		{
			return TeamService.GetAll();
		}

		// GET api/values/5
		public TeamDTO Get(int id)
		{
			return TeamService.GetTeam(id);
		}
	}
}
