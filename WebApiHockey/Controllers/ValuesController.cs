using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class ValuesController : ApiController
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

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
