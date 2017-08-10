namespace Model
{
	public class Position : IIdentificable
	{
		public Position()
		{
			// TODO: Complete member initialization
		}

		public int Id { get; private set; }

		public int Rank { get; set; }

		public int TeamId { get; set; }
		public Team Team { get; set; }

		public int BoardId { get; set; }
		public Board Board { get; set; }

		private int points;
		public int Points { get { return this.GetPoints(); } protected set { } }

		private int GetPoints()
		{
			if (Team == null)
			{
				return points;
			}
			else
			{
				return (this.Team.GetWinMatches() * 3) + this.Team.GetTieMatches();
			}
		}

		public int PlayedMatches { get { return this.GetPlayedMatches(); } protected set { } }

		private int GetPlayedMatches()
		{
			if (Team == null)
			{
				return points;
			}
			else
			{
				return (this.Team.LocalMatches.Count + this.Team.AwayMatches.Count);
			}
		}

		public int WinMatches { get { return this.GetWinMatches(); } protected set { } }

		private int GetWinMatches()
		{
			if (Team == null)
			{
				return points;
			}
			else
			{
				return this.Team.GetWinMatches();
			}
		}

		public int TieMatches { get { return this.GetTieMatches(); } protected set { } }

		private int GetTieMatches()
		{
			if (Team == null)
			{
				return points;
			}
			else
			{
				return this.Team.GetTieMatches();
			}
		}

		public int LoseMatches { get { return this.GetLoseMatches(); } protected set { } }

		private int GetLoseMatches()
		{
			if (Team == null)
			{
				return points;
			}
			else
			{
				return this.Team.GetLoseMatches();
			}
		}

		public int FavorGoals { get { return this.GetFavorGoals(); } protected set { } }

		private int GetFavorGoals()
		{
			if (Team == null)
			{
				return points;
			}
			else
			{
				return this.Team.Goals.Count;
			}
		}

		public int AgainstGoals { get { return this.GetAgainstGoals(); } protected set { } }

		private int GetAgainstGoals()
		{
			if (Team == null)
			{
				return points;
			}
			else
			{
				return this.Team.GetAgainstGoals();
			}
		}

		public int DifferenceGoals { get { return this.GetDifferenceGoals(); } protected set { } }

		private int GetDifferenceGoals()
		{
			if (Team == null)
			{
				return points;
			}
			else
			{
				return (this.GetFavorGoals() - this.GetAgainstGoals());
			}
		}
	}
}
