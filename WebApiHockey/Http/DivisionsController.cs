using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/divisions")]
	public class DivisionsController : ApiController
	{
		private DivisionService DivisionService = new DivisionService();

		[Route("")]
		public IHttpActionResult Get()
		{
			IList<DivisionDTO> divisions = DivisionService.GetAll();

			if (divisions.Count == 0)
			{
				return NotFound();
			}
			return Ok(divisions);
		}

		[Route("{id:int}")]
		public IHttpActionResult Get(int id)
		{
			DivisionDTO division = DivisionService.GetDivision(id);

			if (division == null)
			{
				return NotFound();
			}
			return Ok(division);
		}

		[Route("create/{divisionDTO}")]
		[HttpPost]
		public IHttpActionResult Create(DivisionDTO divisionDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			DivisionService.Create(divisionDTO);
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
			DivisionService.Delete(id);
			return Ok();
		}

		[Route("put/{divisionDTO}")]
		[HttpPut]
		public IHttpActionResult Put(DivisionDTO divisionDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			DivisionService.Put(divisionDto);
			return Ok();
		}
	}
}
