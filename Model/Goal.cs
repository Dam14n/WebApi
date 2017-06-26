namespace Model
{
	/// <summary>
	/// Goal model class.
	/// </summary>
	public class Goal
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Goal"/> class.
		/// </summary>
		public Goal()
		{
		}

		public virtual int GoalId { get; set; }

		public virtual int MatchId { get; set; }

		public virtual Match Match
		{
			get;
			set;
		}

		public virtual int PlayerId { get; set; }

		public virtual Player Player
		{
			get;
			set;
		}
	}
}
