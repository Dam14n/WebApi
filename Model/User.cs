using System.Collections.Generic;

namespace Model
{
	public class User : IIdentificable
	{
		public virtual int Id { get; private set; }

		private IList<Favorite> favorites;

		public virtual IList<Favorite> Favorites
		{
			get { return this.favorites ?? (this.favorites = new List<Favorite>()); }
			protected set { this.favorites = value; }
		}
	}
}
