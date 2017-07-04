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
	}
}
