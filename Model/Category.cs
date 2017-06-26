namespace Model
{
	using System.Collections.Generic;

	/// <summary>
	/// Category model class.
	/// </summary>
	public class Category
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Category"/> class.
		/// </summary>
		public Category()
		{
		}

		public virtual int CategoryId { get; set; }

		/// <summary>
		/// Gets or sets the Category name.
		/// </summary>
		public virtual string Name
		{
			get;
			set;
		}

		public virtual bool Favorite
		{
			get;
			set;
		}

		public virtual int SubDivisionId { get; set; }
		public virtual SubDivision SubDivision { get; set; }

		private IList<Match> matches;

		public virtual IList<Match> Matches
		{
			get { return this.matches ?? (this.matches = new List<Match>()); }
			protected set { this.matches = value; }
		}
	}
}
