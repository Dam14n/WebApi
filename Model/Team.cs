namespace Model
{
	using System.Collections.Generic;

	public class Team : IIdentificable
	{
		public Team()
		{
		}

		public virtual int Id { get; private set; }
		public virtual string Name { get; set; }
		public virtual string Location { get; set; }
		public virtual int Logo { get; set; }
		private IList<Player> players;

		public virtual IList<Player> Players
		{
			get { return this.players ?? (this.players = new List<Player>()); }
			protected set { this.players = value; }
		}

		private IList<Match> localMatches;

		public virtual IList<Match> LocalMatches
		{
			get { return this.localMatches ?? (this.localMatches = new List<Match>()); }
			protected set { this.localMatches = value; }
		}

		private IList<Match> awayMatches;

		public virtual IList<Match> AwayMatches
		{
			get { return this.awayMatches ?? (this.awayMatches = new List<Match>()); }
			protected set { this.awayMatches = value; }
		}

		private IList<Goal> goals;

		public virtual IList<Goal> Goals
		{
			get { return this.goals ?? (this.goals = new List<Goal>()); }
			protected set { this.goals = value; }
		}
	}
}
