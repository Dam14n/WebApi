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
	}
}
