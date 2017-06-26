using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataLayer;
using Model;

namespace WebApiHockey.Controllers
{
	public class ValuesController : ApiController
	{
		private readonly ModelContext _context = new ModelContext();

		// GET api/values
		public List<Division> Get()
		{
			return _context.Divisions.ToList();
			//return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
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
