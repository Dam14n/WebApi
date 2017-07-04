namespace Model
{
	using System.Collections.Generic;

	public class Category : IIdentificable
	{
		public Category()
		{
		}

		public virtual int Id { get; private set; }
		public virtual string Name { get; set; }
		public virtual int SubDivisionId { get; set; }
		public virtual SubDivision SubDivision { get; set; }

		private IList<Match> matches;

		public virtual IList<Match> Matches
		{
			get { return this.matches ?? (this.matches = new List<Match>()); }
			protected set { this.matches = value; }
		}
	}
}
