using System.Collections.Generic;

namespace Model
{
	public class Board : IIdentificable
	{
		public virtual int Id { get; private set; }
		public virtual string Name { get; set; }
		private IList<Position> positions;

		public virtual IList<Position> Positions
		{
			get { return this.positions ?? (this.positions = new List<Position>()); }
			protected set { this.positions = value; }
		}
	}
}
