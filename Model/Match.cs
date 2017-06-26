using System.Collections.Generic;

namespace Model
{
	/// <summary>
	/// Division model class.
	/// </summary>
	public class Match
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Division"/> class.
		/// </summary>
		public Match()
		{
		}

		public virtual int MatchId { get; set; }

		public virtual int CategoryId { get; set; }
		public virtual Category Category { get; set; }

		public virtual int LocalTeamId { get; set; }
		public virtual Team LocalTeam { get; set; }

		public virtual int EnemyTeamId { get; set; }
		public virtual Team EnemyTeam { get; set; }

		private IList<Goal> localGoals;

		public virtual IList<Goal> LocalGoals
		{
			get { return this.localGoals ?? (this.localGoals = new List<Goal>()); }
			protected set { this.localGoals = value; }
		}

		private IList<Goal> enemyGoals;

		public virtual IList<Goal> EnemyGoals
		{
			get { return this.enemyGoals ?? (this.enemyGoals = new List<Goal>()); }
			protected set { this.enemyGoals = value; }
		}
	}
}
