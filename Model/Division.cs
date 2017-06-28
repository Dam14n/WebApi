namespace Model
{
	using System.Collections.Generic;

	public class Division : IIdentificable
	{
		public Division()
		{
		}

		public int DivisionId { get; set; }
		public virtual string Name { get; set; }

		private ICollection<SubDivision> subDivisions;

		public virtual ICollection<SubDivision> SubDivisions
		{
			get { return this.subDivisions ?? (this.subDivisions = new List<SubDivision>()); }
			protected set { this.subDivisions = value; }
		}

		public virtual int Id
		{
			get;
			set;
		}
	}
}
