using System.Collections.Generic;

namespace Model
{
	public class User : IIdentificable
	{
		public virtual int Id { get; private set; }

		private IList<Category> categories;

		public virtual IList<Category> Categories
		{
			get { return this.categories ?? (this.categories = new List<Category>()); }
			protected set { this.categories = value; }
		}
	}
}
