using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/dates")]
	public class DatesController : ApiController
	{
		private DateService dateService = new DateService();

		[Route("")]
		public List<DateDTO> Get()
		{
			return dateService.GetAll();
		}

		[Route("{id:int}")]
		public DateDTO GetDate(int id)
		{
			return dateService.GetDate(id);
		}

		[Route("~/api/categories/{categoryId:int}/dates")]
		public List<DateDTO> GetDatesByCategory(int categoryId)
		{
			return dateService.GetDatesByCategory(categoryId);
		}

		[Route("~/api/categories/{categoryId:int}/dates/{id:int}")]
		public DateDTO GetDateByCategory(int categoryId, int id)
		{
			return dateService.GetDateByCategory(categoryId, id);
		}

		[Route("create")]
		[HttpPost]
		public IHttpActionResult Create(DateDTO dateDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			dateService.Create(dateDTO);
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
			dateService.Delete(id);
			return Ok();
		}

		[Route("put")]
		[HttpPut]
		public IHttpActionResult Put(DateDTO dateDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			dateService.Put(dateDTO);
			return Ok();
		}
	}
}
