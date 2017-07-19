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

		[Route("create")]
		[HttpPost]
		public IHttpActionResult Create(CategoryDTO categoryDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			categoryService.Create(categoryDTO);
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
			categoryService.Delete(id);
			return Ok();
		}

		[Route("put")]
		[HttpPut]
		public IHttpActionResult Put(CategoryDTO categoryDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			categoryService.Put(categoryDTO);
			return Ok();
		}
	}
}
