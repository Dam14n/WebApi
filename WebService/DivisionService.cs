using System.Collections.Generic;
using System.Linq;
using DataLayer;
using Model;

namespace WebService
{
	public class DivisionService
	{
		private readonly ModelContext _context = new ModelContext();

		public List<Division> GetAll()
		{
			return _context.Divisions.ToList();
		}

		public Division GetDivision(int id)
		{
			return _context.Divisions.Find(id);
		}
	}
}
