using System.Collections.Generic;

namespace DTO
{
	public class DivisionDTO
	{
		public int DivisionId { get; set; }
		public virtual string Name { get; set; }
		public ICollection<SubDivisionDTO> SubDivisions { get; set; }
	}
}
