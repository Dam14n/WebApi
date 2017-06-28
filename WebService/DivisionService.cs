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
			return _context.Divisions.ProjectTo<DivisionDTO>().ToList();
		}

		public DivisionDTO GetDivision(int id)
		{
			return _context.Divisions.ProjectTo<DivisionDTO>().FirstOrDefault(div => div.DivisionId == id);
		}
	}
}
