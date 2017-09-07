using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class SubDivisionService
	{
		public List<SubDivisionDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<SubDivision> subDivisions = db.SubDivisions.OrderBy(m => m.Name).ToList();
				List<SubDivisionDTO> dtos = new List<SubDivisionDTO>();

				foreach (var subDivision in subDivisions)
				{
					SubDivisionDTO dto = new SubDivisionDTO();
					dto.Id = subDivision.Id;
					dto.Name = subDivision.Name;
					dto.DivisionId = subDivision.DivisionId;
					dto.CategoriesIds = subDivision.Categories
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public SubDivisionDTO GetSubDivision(int id)
		{
			List<SubDivisionDTO> subDivisions = this.GetAll().Where(m => m.Id == id).ToList();
			return subDivisions.FirstOrDefault();
		}

		public List<SubDivisionDTO> GetSubDivisionsByDivision(int divisionId)
		{
			using (var db = new ModelContext())
			{
				List<SubDivision> subDivisions = db.SubDivisions.Where(m => m.DivisionId == divisionId).OrderBy(m => m.Name).ToList();
				List<SubDivisionDTO> dtos = new List<SubDivisionDTO>();

				foreach (var subDivision in subDivisions)
				{
					SubDivisionDTO dto = new SubDivisionDTO();
					dto.Id = subDivision.Id;
					dto.Name = subDivision.Name;
					dto.DivisionId = subDivision.DivisionId;
					dto.CategoriesIds = subDivision.Categories
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public SubDivisionDTO GetSubDivisionByDivision(int divisionId, int id)
		{
			using (var db = new ModelContext())
			{
				List<SubDivision> subDivisions = db.SubDivisions.Where(m => m.DivisionId == divisionId && m.Id == id).OrderBy(m => m.Name).ToList();
				List<SubDivisionDTO> dtos = new List<SubDivisionDTO>();

				foreach (var subDivision in subDivisions)
				{
					SubDivisionDTO dto = new SubDivisionDTO();
					dto.Id = subDivision.Id;
					dto.Name = subDivision.Name;
					dto.DivisionId = subDivision.DivisionId;
					dto.CategoriesIds = subDivision.Categories
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos.FirstOrDefault();
			}
		}

		public void Create(SubDivisionDTO subDivisionDTO)
		{
			using (var db = new ModelContext())
			{
				SubDivision subDivision = db.SubDivisions.Create();
				subDivision.Name = subDivisionDTO.Name;
				subDivision.DivisionId = subDivisionDTO.DivisionId;
				db.SubDivisions.Add(subDivision);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new ModelContext())
			{
				SubDivision subDivision = db.SubDivisions
					.Where(m => m.Id == id)
					.FirstOrDefault();
				db.Entry(subDivision).State = System.Data.Entity.EntityState.Deleted;
				db.SaveChanges();
			}
		}

		public void Put(SubDivisionDTO subDivisionDTO)
		{
			using (var db = new ModelContext())
			{
				SubDivision existingSubDivision = db.SubDivisions
					.Where(m => m.Id == subDivisionDTO.Id)
					.FirstOrDefault();
				if (existingSubDivision != null)
				{
					existingSubDivision.Name = subDivisionDTO.Name;
					existingSubDivision.DivisionId = subDivisionDTO.DivisionId;
					db.SaveChanges();
				}
			}
		}
	}
}
