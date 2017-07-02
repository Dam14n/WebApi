namespace Model
{
	using System.Collections.Generic;

	/// <summary>
	/// SubDivision model class.
	/// </summary>
	public class SubDivision : IIdentificable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SubDivision"/> class.
		/// </summary>
		public SubDivision()
		{
		}

		/// <summary>
		/// Gets or sets the SubDivision name.
		/// </summary>
		public virtual string Name
		{
			get;
			set;
		}

		public virtual int DivisionId { get; set; }
		public virtual Division Division { get; set; }

		private IList<Category> categories;

		public virtual IList<Category> Categories
		{
			get { return this.categories ?? (this.categories = new List<Category>()); }
			protected set { this.categories = value; }
		}

		public virtual int Id
		{
			get;
			set;
		}
	}
}
