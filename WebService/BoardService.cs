using System.Collections.Generic;
using System.Linq;
using DataLayer;
using Model;

namespace WebService
{
	public class BoardService
	{
		public void AddPositions()
		{
			using (var db = new ModelContext())
			{
				db.Configuration.LazyLoadingEnabled = true;
				Board board = db.Boards.Where(m => m.Id == 1).FirstOrDefault();
				List<Team> teams = db.Teams.ToList();

				foreach (var team in teams)
				{
					Position position = db.Positions.Create();
					var test = team.LocalMatches.ToList();
					var test1 = team.AwayMatches.ToList();
					position.Team = team;
					board.Positions.Add(position);
				}

				db.SaveChanges();
			}
		}
	}
}
