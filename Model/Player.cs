namespace Model
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Player model class.
	/// </summary>
	public class Player
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Player"/> class.
		/// </summary>
		public Player()
		{
		}

		public virtual int PlayerId { get; set; }

		public virtual String Name
		{
			get;
			set;
		}

		public virtual int Age
		{
			get;
			set;
		}

		public virtual int TeamId
		{
			get;
			set;
		}

		public virtual Team Team
		{
			get;
			set;
		}

		private IList<Goal> goals;

		public virtual IList<Goal> Goals
		{
			get { return this.goals ?? (this.goals = new List<Goal>()); }
			protected set { this.goals = value; }
		}
	}
}
