namespace Model
{
	using System.Collections.Generic;

	public class Category : IIdentificable
	{
		public Category()
		{
		}

		public virtual int Id { get; private set; }
		public virtual string Name { get; set; }
		public virtual int SubDivisionId { get; set; }
		public virtual SubDivision SubDivision { get; set; }
		public virtual string url { get; set; }

		private IList<Date> dates;

		public virtual IList<Date> Dates
		{
			get { return this.dates ?? (this.dates = new List<Date>()); }
			protected set { this.dates = value; }
		}

		private IList<Favorite> favorites;

		public virtual IList<Favorite> Favorites
		{
			get { return this.favorites ?? (this.favorites = new List<Favorite>()); }
			protected set { this.favorites = value; }
		}

		private IList<Board> boards;

		public virtual IList<Board> Boards
		{
			get { return this.boards ?? (this.boards = new List<Board>()); }
			protected set { this.boards = value; }
		}
	}
}
