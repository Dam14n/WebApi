using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class MatchesController : ApiController
	{
		private MatchService MatchService = new MatchService();

		// GET api/values
		public List<MatchDTO> Get()
		{
			return MatchService.GetAll();
		}

		// GET api/values/5
		public MatchDTO Get(int id)
		{
			return MatchService.GetMatch(id);
		}
	}
}
