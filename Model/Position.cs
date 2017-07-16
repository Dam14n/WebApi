namespace Model
{
	public class Position : IIdentificable
	{
		public Position()
		{
			// TODO: Complete member initialization
		}

		public virtual int Id { get; private set; }
		public virtual Team Team { get; set; }
		public virtual int Points { get { return this.GetPoints(); } protected set { } }

		private int GetPoints()
		{
			return (this.Team.GetWinMatches() * 3) + this.Team.GetTieMatches();
		}

		public virtual int PlayedMatches { get { return this.GetPlayedMatches(); } protected set { } }

		private int GetPlayedMatches()
		{
			return (this.Team.LocalMatches.Count + this.Team.AwayMatches.Count);
		}

		public virtual int WinMatches { get { return this.GetWinMatches(); } protected set { } }

		private int GetWinMatches()
		{
			return this.Team.GetWinMatches();
		}

		public virtual int TieMatches { get { return this.GetTieMatches(); } protected set { } }

		private int GetTieMatches()
		{
			return this.Team.GetTieMatches();
		}

		public virtual int LoseMatches { get { return this.GetLoseMatches(); } protected set { } }

		private int GetLoseMatches()
		{
			return this.Team.GetLoseMatches();
		}

		public virtual int FavorGoals { get { return this.GetFavorGoals(); } protected set { } }

		private int GetFavorGoals()
		{
			return this.Team.Goals.Count;
		}

		public virtual int AgainstGoals { get { return this.GetAgainstGoals(); } protected set { } }

		private int GetAgainstGoals()
		{
			return this.Team.GetAgainstGoals();
		}

		public virtual int DifferenceGoals { get { return this.GetDifferenceGoals(); } protected set { } }

		private int GetDifferenceGoals()
		{
			return (this.GetFavorGoals() - this.GetAgainstGoals());
		}
	}
}
