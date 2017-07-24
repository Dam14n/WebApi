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

		[Route("create")]
		[HttpPost]
		public IHttpActionResult Create(SubDivisionDTO subDivisionDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			subDivisionService.Create(subDivisionDTO);
			return Ok();
		}

		[Route("delete/{id:int}")]
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (id <= 0)
			{
				return BadRequest("Not a valid division id");
			}
			subDivisionService.Delete(id);
			return Ok();
		}

		[Route("put")]
		[HttpPut]
		public IHttpActionResult Put(SubDivisionDTO subDivisionDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			subDivisionService.Put(subDivisionDTO);
			return Ok();
		}
	}
}
