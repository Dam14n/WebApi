using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class GoalsController : ApiController
	{
		private GoalService GoalService = new GoalService();

		// GET api/values
		public List<GoalDTO> Get()
		{
			return GoalService.GetAll();
		}

		// GET api/values/5
		public GoalDTO Get(int id)
		{
			return GoalService.GetGoal(id);
		}
	}
}
