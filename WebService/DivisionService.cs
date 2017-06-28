using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using DataLayer;
using DTO;

namespace WebService
{
	public class DivisionService
	{
		private readonly ModelContext _context = new ModelContext();

		public List<DivisionDTO> GetAll()
		{
			var asd = _context.Divisions;
			var a = asd.ProjectTo<DivisionDTO>();
			List<DivisionDTO> x = a.ToList();
			return x;
		}

		public DivisionDTO GetDivision(int id)
		{
			return _context.Divisions.ProjectTo<DivisionDTO>().FirstOrDefault(div => div.DivisionId == id);
		}
	}
}
