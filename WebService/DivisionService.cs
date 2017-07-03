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
				List<Division> divisions = db.Divisions.ToList();
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
	}
}
