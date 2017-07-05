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
				List<SubDivision> subDivisions = db.SubDivisions.ToList();
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
				List<SubDivision> subDivisions = db.SubDivisions.Where(m => m.DivisionId == divisionId).ToList();
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
				List<SubDivision> subDivisions = db.SubDivisions.Where(m => m.DivisionId == divisionId && m.Id == id).ToList();
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
	}
}
