using System.Collections.Generic;
using System.Linq;

namespace Model
{
	public class Board : IIdentificable
	{
		public virtual int Id { get; private set; }
		public virtual string Name { get; set; }

		public virtual int CategoryId { get; set; }
		public virtual Category Category { get; set; }

		private IList<Position> positions;

		public virtual IList<Position> Positions
		{
			get { return this.positions ?? (this.positions = new List<Position>()); }
			protected set { this.positions = value; }
		}

		public void orderPositions()
		{
			List<Position> orderedPositions = Positions.OrderByDescending(m => m.Points).ToList();
			foreach (Position position in orderedPositions)
			{
				position.Rank = orderedPositions.IndexOf(position) + 1;
			}
		}
	}
}
