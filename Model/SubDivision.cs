namespace Model
{
	using System.Collections.Generic;

	/// <summary>
	/// SubDivision model class.
	/// </summary>
	public class SubDivision
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SubDivision"/> class.
		/// </summary>
		public SubDivision()
		{
		}

		public virtual int SubDivisionId { get; set; }

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
	}
}
