using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataLayer;
using Model;

namespace Updater
{
	public class UpdaterPositions
	{
		public void startUpdate()
		{
			using (var db = new ModelContext())
			{
				foreach (Category category in db.Categorys.ToList())
				{
					Board board = getBoardOrCreate(db, category);

					DateTime today = DateTime.Today;

					List<Team> teams = db.Teams
						.Include(m => m.AwayMatches)
						.Include(m => m.LocalMatches)
						.Where(m => m.AwayMatches
							.Where(y => y.Date.CategoryId == category.Id && y.DateMatch <= today)
							.Select(y => y.EnemyTeamId)
							.Contains(m.Id))
						.Where(m => m.LocalMatches
							.Where(y => y.Date.CategoryId == category.Id && y.DateMatch <= today)
							.Select(y => y.LocalTeamId)
							.Contains(m.Id))
						.ToList();

					foreach (var team in teams)
					{
						Position position = db.Positions.Create();
						position.Team = team;
						team.Positions.Add(position);
						board.Positions.Add(position);
					}

					orderPositions(db, board);

					db.Boards.Add(board);
				}
				db.SaveChanges();
			}
		}

		private Board getBoardOrCreate(ModelContext db, Category category)
		{
			Board board = db.Boards.Where(m => m.CategoryId == category.Id).FirstOrDefault();
			if (board == null)
			{
				board = db.Boards.Create();
				board.Category = category;
				board.Name = category.Name;
			}
			return board;
		}

		public void orderPositions(ModelContext db, Board board)
		{
			List<Position> orderedPositions = board.Positions.Where(m => m.BoardId == board.Id).OrderByDescending(m => m.Points).ThenByDescending(m => m.DifferenceGoals).ToList();

			foreach (Position position in orderedPositions)
			{
				position.Rank = orderedPositions.IndexOf(position) + 1;
			}
		}
	}
}
