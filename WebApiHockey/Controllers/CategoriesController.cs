using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class CategoriesController : ApiController
	{
		private CategoryService CategoryService = new CategoryService();

		// GET api/values
		public List<CategoryDTO> Get()
		{
			return CategoryService.GetAll();
		}

		// GET api/values/5
		public CategoryDTO Get(int id)
		{
			return CategoryService.GetCategory(id);
		}
	}
}
