using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class CategoryService
	{
		public List<CategoryDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Category> categories = db.Categorys.ToList();
				List<CategoryDTO> dtos = new List<CategoryDTO>();

				foreach (var category in categories)
				{
					CategoryDTO dto = new CategoryDTO();
					dto.Id = category.Id;
					dto.Name = category.Name;
					dto.SubDivisionId = category.SubDivisionId;
					dto.DatesIds = category.Dates
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public CategoryDTO GetCategory(int id)
		{
			List<CategoryDTO> categories = this.GetAll().Where(m => m.Id == id).ToList();
			return categories.FirstOrDefault();
		}

		public List<CategoryDTO> GetCategoriesBySubDivision(int subDivisionId)
		{
			using (var db = new ModelContext())
			{
				List<Category> categories = db.Categorys.Where(m => m.SubDivisionId == subDivisionId).ToList();
				List<CategoryDTO> dtos = new List<CategoryDTO>();

				foreach (var category in categories)
				{
					CategoryDTO dto = new CategoryDTO();
					dto.Id = category.Id;
					dto.Name = category.Name;
					dto.SubDivisionId = category.SubDivisionId;
					dto.DatesIds = category.Dates
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public CategoryDTO GetCategoryBySubDivision(int subDivisionId, int id)
		{
			using (var db = new ModelContext())
			{
				List<Category> categories = db.Categorys.Where(m => m.SubDivisionId == subDivisionId && m.Id == id).ToList();
				List<CategoryDTO> dtos = new List<CategoryDTO>();

				foreach (var category in categories)
				{
					CategoryDTO dto = new CategoryDTO();
					dto.Id = category.Id;
					dto.Name = category.Name;
					dto.SubDivisionId = category.SubDivisionId;
					dto.DatesIds = category.Dates
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos.FirstOrDefault();
			}
		}

		public void Create(CategoryDTO categoryDTO)
		{
			using (var db = new ModelContext())
			{
				Category category = db.Categorys.Create();
				category.Name = categoryDTO.Name;
				category.SubDivisionId = categoryDTO.SubDivisionId;
				db.Categorys.Add(category);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new ModelContext())
			{
				Category category = db.Categorys
					.Where(m => m.Id == id)
					.FirstOrDefault();
				db.Entry(category).State = System.Data.EntityState.Deleted;
				db.SaveChanges();
			}
		}

		public void Put(CategoryDTO categoryDTO)
		{
			using (var db = new ModelContext())
			{
				Category existingCategory = db.Categorys
					.Where(m => m.Id == categoryDTO.Id)
					.FirstOrDefault();
				if (existingCategory != null)
				{
					existingCategory.Name = categoryDTO.Name;
					existingCategory.SubDivisionId = categoryDTO.SubDivisionId;
					db.SaveChanges();
				}
			}
		}
	}
}
