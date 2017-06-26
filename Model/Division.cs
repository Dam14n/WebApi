namespace Model
{
	using System.Collections.Generic;

	/// <summary>
	/// Division model class.
	/// </summary>
	public class Division
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Division"/> class.
		/// </summary>
		public Division()
		{
		}

		public int DivisionId { get; set; }

		/// <summary>
		/// Gets or sets the Division name.
		/// </summary>
		public virtual string Name
		{
			get;
			set;
		}

		private ICollection<SubDivision> subDivisions;

		public virtual ICollection<SubDivision> SubDivisions
		{
			get { return this.subDivisions ?? (this.subDivisions = new List<SubDivision>()); }
			protected set { this.subDivisions = value; }
		}
	}
}
