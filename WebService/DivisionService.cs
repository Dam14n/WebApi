using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class DivisionService
	{
		public List<DivisionDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Division> divisions = db.Divisions.OrderBy(m => m.Name).ToList();
				List<DivisionDTO> dtos = new List<DivisionDTO>();

				foreach (var division in divisions)
				{
					DivisionDTO dto = new DivisionDTO();
					dto.Id = division.Id;
					dto.Name = division.Name;
					dto.SubDivisionsIds = division.SubDivisions
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public DivisionDTO GetDivision(int id)
		{
			List<DivisionDTO> divisions = this.GetAll().Where(div => div.Id == id).ToList();
			return divisions.FirstOrDefault();
		}

		public void Create(DivisionDTO divisionDTO)
		{
			using (var db = new ModelContext())
			{
				Division division = db.Divisions.Create();
				division.Name = divisionDTO.Name;
				db.Divisions.Add(division);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new ModelContext())
			{
				Division division = db.Divisions
					.Where(m => m.Id == id)
					.FirstOrDefault();
				db.Entry(division).State = System.Data.Entity.EntityState.Deleted;
				db.SaveChanges();
			}
		}

		public void Put(DivisionDTO divisionDto)
		{
			using (var db = new ModelContext())
			{
				Division existingDivision = db.Divisions
					.Where(m => m.Id == divisionDto.Id)
					.FirstOrDefault();
				if (existingDivision != null)
				{
					existingDivision.Name = divisionDto.Name;
					db.SaveChanges();
				}
			}
		}
	}
}
