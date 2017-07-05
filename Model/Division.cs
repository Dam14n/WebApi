namespace Model
{
	using System.Collections.Generic;

	public class Division : IIdentificable
	{
		public Division()
		{
		}

		public virtual int Id { get; private set; }
		public virtual string Name { get; set; }

		private IList<SubDivision> subDivisions;

		public virtual IList<SubDivision> SubDivisions
		{
			get { return this.subDivisions ?? (this.subDivisions = new List<SubDivision>()); }
			protected set { this.subDivisions = value; }
		}
	}
}
