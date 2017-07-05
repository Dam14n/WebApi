using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	[RoutePrefix("api/divisions")]
	public class DivisionsController : ApiController
	{
		private DivisionService DivisionService = new DivisionService();

		[Route("")]
		public List<DivisionDTO> Get()
		{
			return DivisionService.GetAll();
		}

		[Route("{id:int}")]
		public DivisionDTO Get(int id)
		{
			return DivisionService.GetDivision(id);
		}
	}
}
