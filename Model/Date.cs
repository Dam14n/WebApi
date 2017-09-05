using System;
using System.Collections.Generic;

namespace Model
{
	public class Date : IIdentificable
	{
		public virtual int Id { get; private set; }
		public virtual DateTime DateMatch { get; set; }
		public virtual int DateNumber { get; set; }
		public virtual int CategoryId { get; set; }
		public virtual Category Category { get; set; }

		private IList<Match> matches;

		public virtual IList<Match> Matches
		{
			get { return this.matches ?? (this.matches = new List<Match>()); }
			protected set { this.matches = value; }
		}
	}
}
