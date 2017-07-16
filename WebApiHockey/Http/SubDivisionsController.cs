using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/subdivisions")]
	public class SubDivisionsController : ApiController
	{
		private SubDivisionService subDivisionService = new SubDivisionService();

		[Route("")]
		public List<SubDivisionDTO> GetSubDivisions()
		{
			return subDivisionService.GetAll();
		}

		[Route("{id:int}")]
		public SubDivisionDTO GetSubDivision(int id)
		{
			return subDivisionService.GetSubDivision(id);
		}

		[Route("~/api/divisions/{divisionId:int}/subdivisions")]
		public List<SubDivisionDTO> GetSubDivisionsByDivision(int divisionId)
		{
			return subDivisionService.GetSubDivisionsByDivision(divisionId);
		}

		[Route("~/api/divisions/{divisionId:int}/subdivisions/{id:int}")]
		public SubDivisionDTO GetSubDivisionByDivision(int divisionId, int id)
		{
			return subDivisionService.GetSubDivisionByDivision(divisionId, id);
		}
	}
}
