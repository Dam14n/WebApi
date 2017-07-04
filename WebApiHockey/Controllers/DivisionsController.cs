using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class DivisionsController : ApiController
	{
		private DivisionService DivisionService = new DivisionService();

		public List<DivisionDTO> Get()
		{
			return DivisionService.GetAll();
		}

		public DivisionDTO Get(int id)
		{
			return DivisionService.GetDivision(id);
		}
	}
}
