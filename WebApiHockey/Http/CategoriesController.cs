using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/categories")]
	public class CategoriesController : ApiController
	{
		private CategoryService categoryService = new CategoryService();

		[Route("")]
		public List<CategoryDTO> Get()
		{
			return categoryService.GetAll();
		}

		[Route("{id:int}")]
		public CategoryDTO Get(int id)
		{
			return categoryService.GetCategory(id);
		}

		[Route("~/api/subdivisions/{subDivisionId:int}/categories")]
		public List<CategoryDTO> GetCategoriesBySubDivision(int subDivisionId)
		{
			return categoryService.GetCategoriesBySubDivision(subDivisionId);
		}

		[Route("~/api/subdivisions/{subDivisionId:int}/categories/{id:int}")]
		public CategoryDTO GetCategoryBySubDivision(int subDivisionId, int id)
		{
			return categoryService.GetCategoryBySubDivision(subDivisionId, id);
		}
	}
}
