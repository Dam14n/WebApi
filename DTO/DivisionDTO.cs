using System.Collections.Generic;

namespace DTO
{
	public class DivisionDTO
	{
		public int DivisionId { get; set; }
		public virtual string Name { get; set; }

		private ICollection<SubDivisionDTO> subDivisions;

		public virtual ICollection<SubDivisionDTO> SubDivisions
		{
			get { return this.subDivisions ?? (this.subDivisions = new List<SubDivisionDTO>()); }
			protected set { this.subDivisions = value; }
		}
	}
}
