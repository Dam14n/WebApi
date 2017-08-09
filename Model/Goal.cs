namespace Model
{
	public class Goal : IIdentificable
	{
		public Goal()
		{
		}

		public virtual int Id { get; private set; }
		public virtual int MatchId { get; set; }
		public virtual Match Match { get; set; }
		public virtual int? PlayerId { get; set; }
		public virtual Player Player { get; set; }
		public virtual int TeamId { get; set; }
		public virtual Team Team { get; set; }
	}
}
