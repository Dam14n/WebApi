using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class SubDivisionController : ApiController
	{
		private DivisionService DivisionService = new DivisionService();

		// GET api/values
		public List<DivisionDTO> Get()
		{
			return DivisionService.GetAll();
		}

		// GET api/values/5
		public DivisionDTO Get(int id)
		{
			return DivisionService.GetDivision(id);
		}
	}
}
