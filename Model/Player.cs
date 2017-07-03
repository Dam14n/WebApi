namespace Model
{
	using System.Collections.Generic;

	public class Player : IIdentificable
	{
		public Player()
		{
		}

		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual int Age { get; set; }
		public virtual int TeamId { get; set; }
		public virtual Team Team { get; set; }

		private IList<Goal> goals;

		public virtual IList<Goal> Goals
		{
			get { return this.goals ?? (this.goals = new List<Goal>()); }
			protected set { this.goals = value; }
		}
	}
}
