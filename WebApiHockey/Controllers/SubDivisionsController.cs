using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class SubDivisionsController : ApiController
	{
		private SubDivisionService subDivisionService = new SubDivisionService();

		public List<SubDivisionDTO> GetSubDivisions()
		{
			return subDivisionService.GetAll();
		}

		public SubDivisionDTO GetSubDivision(int id)
		{
			return subDivisionService.GetSubDivision(id);
		}

		public List<SubDivisionDTO> GetSubDivisionsByDivision(int divisionId)
		{
			return subDivisionService.GetSubDivisionsByDivision(divisionId);
		}

		public SubDivisionDTO GetSubDivisionByDivision(int divisionId, int id)
		{
			return subDivisionService.GetSubDivisionByDivision(divisionId, id);
		}
	}
}
