using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class DivisionService
	{
		private readonly ModelContext _context = new ModelContext();

		public List<Division> GetAll()
		{
			return _context.Divisions
				//.ProjectTo<DivisionDTO>()
				.ToList();
			//this.QueryWhere(AutoMapper.Mapper., null, null, true);
			/*var entityModels = (IQueryable<Division>)_context.Divisions;

			var entityModelsEnumerable = (IEnumerable<Division>)entityModels;

			var entityDtos = entityModelsEnumerable.ToList();
			return entityDtos;*/

			/*	var asd = _context.Divisions;
				var a = asd.ProjectTo<DivisionDTO>();
				List<DivisionDTO> x = a.ToList();
				return x;*/
		}

		public DivisionDTO GetDivision(int id)
		{
			return _context.Divisions.ProjectTo<DivisionDTO>().FirstOrDefault(div => div.Id == id);
		}
	}
}
