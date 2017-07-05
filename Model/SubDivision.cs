namespace Model
{
	using System.Collections.Generic;

	/// <summary>
	/// SubDivision model class.
	/// </summary>
	public class SubDivision : IIdentificable
	{
		public SubDivision()
		{
		}

		public virtual int Id { get; private set; }
		public virtual string Name { get; set; }

		public virtual int DivisionId { get; set; }
		public virtual Division Division { get; set; }

		private IList<Category> categories;

		public virtual IList<Category> Categories
		{
			get { return this.categories ?? (this.categories = new List<Category>()); }
			protected set { this.categories = value; }
		}
	}
}
