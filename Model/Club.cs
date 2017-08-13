using System.Collections.Generic;

namespace Model
{
	public class Club : IIdentificable
	{
		public virtual int Id { get; private set; }
		public virtual int Latitude { get; set; }
		public virtual int Longitude { get; set; }
		public virtual string Name { get; set; }
		public virtual int? LogoId { get; set; }
		public virtual Logo Logo { get; set; }

		private IList<Team> teams;

		public virtual IList<Team> Teams
		{
			get { return this.teams ?? (this.teams = new List<Team>()); }
			protected set { this.teams = value; }
		}
	}
}
