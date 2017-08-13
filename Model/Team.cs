namespace Model
{
	using System.Collections.Generic;

	public class Team : IIdentificable
	{
		public Team()
		{
		}

		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual int? ClubId { get; set; }
		public virtual Club Club { get; set; }

		private IList<Position> positions;

		public virtual IList<Position> Positions
		{
			get { return this.positions ?? (this.positions = new List<Position>()); }
			set { this.positions = value; }
		}

		private IList<Player> players;

		public virtual IList<Player> Players
		{
			get { return this.players ?? (this.players = new List<Player>()); }
			set { this.players = value; }
		}

		private IList<Match> localMatches;

		public virtual IList<Match> LocalMatches
		{
			get { return this.localMatches ?? (this.localMatches = new List<Match>()); }
			set { this.localMatches = value; }
		}

		private IList<Match> awayMatches;

		public virtual IList<Match> AwayMatches
		{
			get { return this.awayMatches ?? (this.awayMatches = new List<Match>()); }
			set { this.awayMatches = value; }
		}

		private IList<Goal> goals;

		public virtual IList<Goal> Goals
		{
			get { return this.goals ?? (this.goals = new List<Goal>()); }
			set { this.goals = value; }
		}

		public int GetWinMatches()
		{
			int winMatches = 0;
			foreach (Match match in localMatches)
			{
				if (match.GetResult(this.Id) == MatchResult.WIN)
				{
					winMatches += 1;
				}
			}
			foreach (Match match in awayMatches)
			{
				if (match.GetResult(this.Id) == MatchResult.WIN)
				{
					winMatches += 1;
				}
			}
			return winMatches;
		}

		public int GetTieMatches()
		{
			int tieMatches = 0;
			foreach (Match match in localMatches)
			{
				if (match.GetResult(this.Id) == MatchResult.TIE)
				{
					tieMatches += 1;
				}
			}
			foreach (Match match in awayMatches)
			{
				if (match.GetResult(this.Id) == MatchResult.TIE)
				{
					tieMatches += 1;
				}
			}
			return tieMatches;
		}

		public int GetLoseMatches()
		{
			int loseMatches = 0;
			foreach (Match match in localMatches)
			{
				if (match.GetResult(this.Id) == MatchResult.LOSE)
				{
					loseMatches += 1;
				}
			}
			foreach (Match match in awayMatches)
			{
				if (match.GetResult(this.Id) == MatchResult.LOSE)
				{
					loseMatches += 1;
				}
			}
			return loseMatches;
		}

		public int GetAgainstGoals()
		{
			int againstGoals = 0;
			foreach (Match match in awayMatches)
			{
				againstGoals += match.GetGoalsAgainst(this.Id);
			}
			return againstGoals;
		}
	}
}
