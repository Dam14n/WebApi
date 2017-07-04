using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class CategoriesController : ApiController
	{
		private CategoryService categoryService = new CategoryService();

		public List<CategoryDTO> Get()
		{
			return categoryService.GetAll();
		}

		public CategoryDTO Get(int id)
		{
			return categoryService.GetCategory(id);
		}

		public List<CategoryDTO> GetCategoriesBySubDivision(int subDivisionId)
		{
			return categoryService.GetCategoriesBySubDivision(subDivisionId);
		}

		public CategoryDTO GetCategoryBySubDivision(int subDivisionId, int id)
		{
			return categoryService.GetCategoryBySubDivision(subDivisionId, id);
		}
	}
}
