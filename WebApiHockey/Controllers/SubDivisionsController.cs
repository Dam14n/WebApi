using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class SubDivisionsController : ApiController
	{
		private SubDivisionService subDivisionService = new SubDivisionService();

		// GET api/values
		public List<SubDivisionDTO> Get()
		{
			return subDivisionService.GetAll();
		}

		// GET api/values/5
		public SubDivisionDTO Get(int id)
		{
			return subDivisionService.GetSubDivision(id);
		}
	}
}
