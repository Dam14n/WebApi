using System.Collections.Generic;

namespace Model
{
	public class Match : IIdentificable
	{
		public Match()
		{
		}

		public virtual int Id { get; private set; }

		public virtual int CategoryId { get; set; }
		public virtual Category Category { get; set; }

		public virtual int? LocalTeamId { get; set; }
		public virtual Team LocalTeam { get; set; }

		public virtual int? EnemyTeamId { get; set; }
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
