namespace Model
{
	using System;
	using System.Collections.Generic;

	public class Team : IIdentificable
	{
		public Team()
		{
		}

		public int Id { get; set; }
		public virtual String Name { get; set; }
		public virtual String Location { get; set; }
		public virtual int Logo { get; set; }
		private IList<Player> players;

		public virtual IList<Player> Players
		{
			get { return this.players ?? (this.players = new List<Player>()); }
			protected set { this.players = value; }
		}

		private IList<Match> matches;

		public virtual IList<Match> Matches
		{
			get { return this.matches ?? (this.matches = new List<Match>()); }
			protected set { this.matches = value; }
		}
	}
}
